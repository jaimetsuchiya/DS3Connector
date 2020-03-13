using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ds3sdk;
using Newtonsoft.Json;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        static DS3Document _DS3Doc;
        static DS3Doctype _DS3DocType;
        static DS3Attacheddoc _DS3AttachedDoc;
        static DS3User _DS3User;

        public MainWindow()
        {
            _DS3Doc = new DS3Document();
            _DS3DocType = new DS3Doctype();
            _DS3AttachedDoc = new DS3Attacheddoc();
            _DS3User = new DS3User();

            InitializeComponent();

        }


        private void rdoCreate_Checked(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\create_doc_url.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3Doc.ErrorMessage);
            }
        }

        private void rdoUpdate_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                //string inputFileName = AppDir + @"\create_doc_base64.json";
                string inputFileName = AppDir + @"\json_samples\update_doc_url.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3Doc.ErrorMessage);
            }

        }

        private void btnExec_Click(object sender, RoutedEventArgs e)
        {

            if (rdoCreate.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
                {
                    string mContent = _DS3Doc.Create(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3Doc.ErrorMessage);
                }

            }

            if (rdoSearch.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
                {
                    string mContent = _DS3Doc.Search(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3Doc.ErrorMessage);
                }

            }

            if (rdoUpdate.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
                {
                    string mContent = _DS3Doc.Update(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3Doc.ErrorMessage);
                }

            }

            if (rdoDelete.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
                {
                    string mContent = _DS3Doc.Delete(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3Doc.ErrorMessage);
                }

            }

            if (rdoDoctype.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3DocType.ErrorMessage))
                {
                    string mContent = _DS3DocType.Search(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3DocType.ErrorMessage);
                }
            }

            if (rdoAttachSearch.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
                {
                    string mContent = _DS3AttachedDoc.Search(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
                }
            }

            if (rdoAttachedCreate.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
                {
                    string mContent = _DS3AttachedDoc.Create(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
                }
            }

            if (rdoAttachedUpdate.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
                {
                    string mContent = _DS3AttachedDoc.Update(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
                }
            }

            if (rdoAttachedDelete.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
                {
                    string mContent = _DS3AttachedDoc.Delete(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
                }
            }

            if (rdoUser.IsChecked == true)
            {
                if (String.IsNullOrEmpty(_DS3User.ErrorMessage))
                {
                    string mContent = _DS3User.Search(txtJson.Text);
                    var jsonContect = JsonConvert.DeserializeObject<dynamic>(mContent);
                    txtJsonResult.Text = jsonContect.ToString();
                }
                else
                {
                    MessageBox.Show(_DS3User.ErrorMessage);
                }
            }

        }

        private void rdoSearch_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\search.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3Doc.ErrorMessage);
            }
        }

        private void rdoDelete_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3Doc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\delete.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3Doc.ErrorMessage);
            }

        }

        private void rdoDoctype_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3DocType.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\doc_type.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3DocType.ErrorMessage);
            }

        }

        private void rdoAttachSearch_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\attached_search.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
            }
        }

        private void rdoAttachedDelete_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\attached_delete_by_id.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
            }

        }

        private void rdoUser_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3User.ErrorMessage))
            {
                txtJson.Text = String.Empty;
            }
            else
            {
                MessageBox.Show(_DS3User.ErrorMessage);
            }

        }

        private void rdoAttachedCreate_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\attached_create.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
            }

        }

        private void rdoAttachedUpdate_Checked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(_DS3AttachedDoc.ErrorMessage))
            {
                string AppDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                string inputFileName = AppDir + @"\json_samples\attached_update.json";
                string jsonString = File.ReadAllText(inputFileName);
                txtJson.Text = jsonString;
            }
            else
            {
                MessageBox.Show(_DS3AttachedDoc.ErrorMessage);
            }

        }
    }
}
