using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml;

namespace ITFounder
{
    public partial class SearchPage : Form
    {
        #region Variables

        IList<string> _mCompanyNames;
        IList<string> _mCompanyAddress;
        XmlDocument _mResponseDoc;
        string _mSearchQuery;
        int _mSerialNum;
        string _mApikey;
        string _mNameAddress;
        string _mUrlToBePassed;
        bool _mIsNumeric;
        string _mLocationSplitter;

        public string MSearchQuery { get => _mSearchQuery; set => _mSearchQuery = value; }

        public delegate void UpdateControlsDelegate(string val);

        #endregion

        #region Constructor

        public SearchPage()
        {
            _mCompanyNames = new List<string>();
            _mCompanyAddress = new List<string>();
            _mNameAddress = string.Empty;
            this.BackColor = Color.Green;
            _mResponseDoc = new XmlDocument();
            InitializeComponent();
            _mApikey = "&key=AIzaSyCIFY1-JBm_cNht8Lfuncb4jCeXPXWubnA";
            _mIsNumeric = true;
            _mSearchQuery = SearchQueryBox.Text;

        }

        #endregion

        #region SearchButton

        /// <summary>
        /// This method is called when Search Button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            if (ResultList.Items != null && ResultList.Items.Count > 0)
            {
                ResultList.Items.Clear();
            }

            List<string> lstComp = new List<string>();
            ValidationOnSearchLocation(_mSearchQuery);


            _mUrlToBePassed = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=IT+companies+in+" + SearchQuerySplitter(_mSearchQuery) + _mApikey;

            RequestToApi();
            Result();
        }

        #endregion

        #region Validation

        /// <summary>
        /// This method is for the validation over the location enter by the user
        /// </summary>
        /// <param name="searchquery">this is the location entered by user</param>
        private void ValidationOnSearchLocation(string searchquery)
        {
            try
            {
                if (string.IsNullOrEmpty(searchquery))
                {
                    errorLable.Text = " !!! Please enter a location";
                    errorLable.Visible = true;
                    SearchQueryBox.BackColor = Color.Red;
                }
                else
                {
                    foreach (char c in searchquery)
                    {
                        if (c < '0' || c > '9')
                            _mIsNumeric = false;
                    }

                    if (_mIsNumeric == true)
                    {
                        errorLable.Text = " !!! Please enter a valid location";
                        errorLable.Visible = true;
                        SearchQueryBox.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region LocationSplitter

        /// <summary>
        /// This method is splitting the location enterd by user,
        /// in the fromat in which it can be passed in api request
        /// </summary>
        /// <param name="searchquery">Location enter by user</param>
        /// <returns>It returns the string in the form "word1 + word2 +..."</returns>
        private string SearchQuerySplitter(string searchquery)
        {
            string[] splittedWord = searchquery.Split(' ');
            foreach (var word in splittedWord)
            {
                _mLocationSplitter = _mLocationSplitter + word + "+";
            }
            return _mLocationSplitter;
        }

        #endregion

        #region RequestToApi

        /// <summary>
        ///  This method is sending request to google places api and getting response in xml format
        /// </summary>
        private void RequestToApi()
        {
            HttpClient client = new HttpClient();
            Task.Run(async () =>
            {
                HttpResponseMessage response = await client.GetAsync(_mUrlToBePassed);
                string responseString = await response.Content.ReadAsStringAsync();
                XmlParsing(responseString);

            });
        }

        #endregion

        #region XmlParsing

        /// <summary>
        /// This method is for the parsing of xml response fetch from api
        /// </summary>
        /// <param name="responsestring">string send by api</param>
        private void XmlParsing(string responsestring)
        {
            _mResponseDoc.LoadXml(responsestring);
            XmlNodeList nameList = _mResponseDoc.GetElementsByTagName("name");
            XmlNodeList addressList = _mResponseDoc.GetElementsByTagName("formatted_address");
            foreach (XmlNode n in nameList)
            {
                _mCompanyNames.Add(n.InnerText);
            }

            foreach (XmlNode n in addressList)
            {
                _mCompanyAddress.Add(n.InnerText);
            }
        }

        #endregion

        #region Result

        /// <summary>
        /// This method is joining two lists Namelist and Addresslist and showing Result
        /// </summary>
        private void Result()
        {
            _mSerialNum = 1;
            foreach (var word in _mCompanyNames.Zip(_mCompanyAddress, (companyNamesObj, companyAddressObj) => new { companyNamesObj, companyAddressObj }))
            {
                _mNameAddress = (_mSerialNum + "." + word.companyNamesObj + "\n " + word.companyAddressObj + "\n" + "\n");
                try
                {
                    if (ResultList.InvokeRequired)
                    {
                        this.BeginInvoke(new UpdateControlsDelegate(UpdateControls), _mNameAddress);
                    }
                    else
                    {
                        UpdateControls(_mNameAddress);
                    }
                }
                catch (Exception ex)
                {

                }
                _mSerialNum++;
            }
        }

        private void UpdateControls(string val)
        {
            ResultList.Items.Add(val);
        }

        #endregion

        #region ExitButton

        /// <summary>
        /// This method is for exit button.when user click it will close the tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}