// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="John">
//  Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace GPLX.App.Desktop.Forms.Membership
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using GPLX.Data;
    using GPLX.Data.BusinessService;
    using GPLX.Data.DataAccess;
    using GPLX.Data.DataModel;
    using GPLX.Data.Enum;
    using GPLX.App.Desktop.Properties;

    /// <summary>
    /// Manage screen - To view, search, print, export club members information
    /// </summary>
    public partial class Manage : Form
    {
        /// <summary>
        /// Instance of DataGridViewPrinter
        /// </summary>
        private DataGridViewPrinter dataGridViewPrinter;

        /// <summary>
        /// Interface of ClubMemberService
        /// </summary>
        private IClubMemberService clubMemberService;

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// Member id
        /// </summary>
        private int memberId;

        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        public Manage()
        {
            this.InitializeComponent();
            this.InitializeResourceString();
            this.InitializeDropDownList();
            this.InitilizeDataGridViewStyle();
            this.clubMemberService = new ClubMemberService();
            this.ResetRegistration();
            this.ResetSearch();
        }

        /// <summary>
        /// Initializes resource strings
        /// </summary>
        private void InitializeResourceString()
        {
            // Registeration
            //lblName.Text = Resources.Registration_Name_Label_Text;
            //lblDateOfBirth.Text = Resources.Registration_DateOfBirth_Label_Text;
            //lblOccupation.Text = Resources.Registration_Occupation_Label_Text;
            //lblMaritalStatus.Text = Resources.Registration_MaritalStatus_Label_Text;
            //lblHealthStatus.Text = Resources.Registration_HealthStatus_Label_Text;
            //lblSalary.Text = Resources.Registration_Salary_Label_Text;
            //lblNoOfChildren.Text = Resources.Registration_Children_Label_Text;
            //btnRegister.Text = Resources.Registration_Register_Button_Text;

            // Search, Print, Export, Update, Delete
            //btnSearch.Text = Resources.Search_Search_Button_Text;
            //btnRefresh.Text = Resources.Search_Refresh_Button_Text;
            //btnPrintPreview.Text = Resources.Print_PrintPreview_Button_Text;
            //btnPrint.Text = Resources.Print_Print_Button_Text;
            //btnExport.Text = Resources.Export_Button_Text;
            //btnUpdate.Text = Resources.Update_Button_Text;
            //btnDelete.Text = Resources.Delete_Button_Text;
        }

        /// <summary>
        /// Initializes all dropdown controls
        /// </summary>
        private void InitializeDropDownList()
        {
            //cmbOccupation.DataSource = Enum.GetValues(typeof(Occupation));
            //cmbMaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            //cmbHealthStatus.DataSource = Enum.GetValues(typeof(HealthStatus));

            //cmbSearchOccupation.DataSource = Enum.GetValues(typeof(Occupation));
            //cmbSearchMaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            //cmbOperand.SelectedIndex = 0;

            //ThuyetLV
            List<TmpObj> listTrangThai = new List<TmpObj>();

            listTrangThai.Add(new TmpObj("03", "Chưa kết xuất"));
            listTrangThai.Add(new TmpObj("04", "Đã kết xuất"));

            cbStatus.DataSource = listTrangThai;
            cbStatus.DisplayMember = "nText";
            cbStatus.ValueMember = "nValue";
        }

        /// <summary>
        /// Resets search criteria
        /// </summary>
        private void ResetSearch()
        {
            //cmbSearchMaritalStatus.SelectedIndex = -1;
            //cmbSearchOccupation.SelectedIndex = -1;
            //cmbOperand.SelectedIndex = 0;
        }

        /// <summary>
        /// Resets the registration screen
        /// </summary>
        private void ResetRegistration()
        {
            //txtName.Text = string.Empty;
            //txtSalary.Text = string.Empty;
            //txtNoOfChildren.Text = string.Empty;
            //cmbOccupation.SelectedIndex = -1;
            //cmbHealthStatus.SelectedIndex = -1;
            //cmbMaritalStatus.SelectedIndex = -1;
        }

        /// <summary>
        /// Initializes all dropdown controls in update section
        /// </summary>
        private void InitializeUpdate()
        {
            //cmb2Occupation.DataSource = Enum.GetValues(typeof(Occupation));
            //cmb2MaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            //cmb2HealthStatus.DataSource = Enum.GetValues(typeof(HealthStatus));
        }

        /// <summary>
        /// Resets the update section of manage screen
        /// </summary>
        private void ResetUpdate()
        {
            //txt2Name.Text = string.Empty;
            //txt2Salary.Text = string.Empty;
            //txt2NoOfChildren.Text = string.Empty;
            //cmb2Occupation.SelectedIndex = -1;
            //cmb2HealthStatus.SelectedIndex = -1;
            //cmb2MaritalStatus.SelectedIndex = -1;
        }

        /// <summary>
        /// Validates registration input
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateRegistration()
        {
            this.errorMessage = string.Empty;

            //if (txtName.Text.Trim() == string.Empty)
            //{
            //    this.AddErrorMessage(Resources.Registration_Name_Required_Text);
            //}

            //if (cmbOccupation.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_Occupation_Select_Text);
            //}

            //if (cmbMaritalStatus.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_MaritalStatus_Select_Text);
            //}

            //if (cmbHealthStatus.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_HealthStatus_Select_Text);
            //}

            return this.errorMessage != string.Empty ? false : true;
        }

        /// <summary>
        /// Validates update data
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateUpdate()
        {
            this.errorMessage = string.Empty;

            //if (txt2Name.Text.Trim() == string.Empty)
            //{
            //    this.AddErrorMessage(Resources.Registration_Name_Required_Text);
            //}

            //if (cmb2Occupation.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_Occupation_Select_Text);
            //}

            //if (cmb2MaritalStatus.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_MaritalStatus_Select_Text);
            //}

            //if (cmb2HealthStatus.SelectedIndex == -1)
            //{
            //    this.AddErrorMessage(Resources.Registration_HealthStatus_Select_Text);
            //}

            return this.errorMessage != string.Empty ? false : true;
        }

        /// <summary>
        /// To generate the error message
        /// </summary>
        /// <param name="error">error message</param>
        private void AddErrorMessage(string error)
        {
            if (this.errorMessage == string.Empty)
            {
                this.errorMessage = Resources.Error_Message_Header + "\n\n";
            }

            this.errorMessage += error + "\n";
        }

        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                //Resources.System_Error_Message, 
                Resources.System_Error_Message_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Initializes data grid view style
        /// </summary>
        private void InitilizeDataGridViewStyle()
        {
            // Setting the style of the DataGridView control
            //dataGridViewMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            //dataGridViewMembers.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            //dataGridViewMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //dataGridViewMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridViewMembers.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            //dataGridViewMembers.DefaultCellStyle.BackColor = Color.Empty;
            //dataGridViewMembers.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            //dataGridViewMembers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //dataGridViewMembers.GridColor = SystemColors.ControlDarkDark;
        }

        /// <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
        private void LoadDataGridView(DataTable data)
        {
            // Data grid view column setting            
            //dataGridViewMembers.DataSource = data;
            //dataGridViewMembers.DataMember = data.TableName;
            //dataGridViewMembers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Method to set up the printing
        /// </summary>
        /// <param name="isPrint">isPrint value</param>
        /// <returns>true or false</returns>
        private bool SetupPrinting(bool isPrint)
        {
            //PrintDialog printDialog = new PrintDialog();
            //printDialog.AllowCurrentPage = false;
            //printDialog.AllowPrintToFile = false;
            //printDialog.AllowSelection = false;
            //printDialog.AllowSomePages = false;
            //printDialog.PrintToFile = false;
            //printDialog.ShowHelp = false;
            //printDialog.ShowNetwork = false;

            //if (isPrint)
            //{
            //    if (printDialog.ShowDialog() != DialogResult.OK)
            //    {
            //        return false;
            //    }
            //}

            //this.PrintReport.DocumentName = "MembersReport";
            //this.PrintReport.PrinterSettings = printDialog.PrinterSettings;
            //this.PrintReport.DefaultPageSettings = printDialog.PrinterSettings.DefaultPageSettings;
            //this.PrintReport.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            //this.dataGridViewPrinter = new DataGridViewPrinter(dataGridViewMembers, PrintReport, true, true, Resources.Report_Header, new Font("Tahoma", 13, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        /// <summary>
        /// Click event to handle registration
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Register_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Diagnostics.Debug.WriteLine(" IsServerConnected: " + Ultils.IsServerConnected().ToString());

            //    // Check if the validation passes
            //    if (this.ValidateRegistration())
            //    {
            //        // Assign the values to the model
            //        ClubMemberModel clubMemberModel = new ClubMemberModel()
            //        {
            //            Id = 0,
            //            Name = txtName.Text.Trim(),
            //            DateOfBirth = dtDateOfBirth.Value,
            //            Occupation = (Occupation)cmbOccupation.SelectedValue,
            //            HealthStatus = (HealthStatus)cmbHealthStatus.SelectedValue,
            //            MaritalStatus = (MaritalStatus)cmbMaritalStatus.SelectedValue,
            //            Salary = txtSalary.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtSalary.Text),
            //            NumberOfChildren = txtNoOfChildren.Text.Trim() == string.Empty ? 0 : Convert.ToInt16(txtNoOfChildren.Text)
            //        };

            //        // Call the service method and assign the return status to variable
            //        var success = this.clubMemberService.RegisterClubMember(clubMemberModel);

            //        // if status of success variable is true then display a information else display the error message
            //        if (success)
            //        {
            //            // display the message box
            //            MessageBox.Show(
            //                Resources.Registration_Successful_Message,
            //                Resources.Registration_Successful_Message_Title,
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);

            //            // Reset the screen
            //            this.ResetRegistration();
            //        }
            //        else
            //        {
            //            // display the error messge
            //            MessageBox.Show(
            //                Resources.Registration_Error_Message,
            //                Resources.Registration_Error_Message_Title,
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        // Display the validation failed message
            //        MessageBox.Show(
            //            this.errorMessage,
            //            Resources.Registration_Error_Message_Title,
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        /// <summary>
        /// Key press Event to accept only numeric value
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">key press event data</param>
        private void Salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

        /// <summary>
        /// Key press Event to accept only numeric value
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        private void Children_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        /// <summary>
        /// Event to handle tab selection
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("tab.SelectedIndex: " + tab.SelectedIndex);
                if (tab.SelectedIndex == 0)
                {
                    //Check ket noi export
                    if (!Ultils.IsServerConnected(Ultils.GetDBConnection()))
                    {
                        this.ShowErrorMessage(new Exception("Lỗi kết nối DB"));
                    }
                }
                else if (tab.SelectedIndex == 1)
                {
                    //Check ket noi import
                    if (!Ultils.IsServerConnected(Ultils.GetDBConnectionImport()))
                    {
                        this.ShowErrorMessage(new Exception("Lỗi kết nối DB"));
                    }
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Event to handle the data formatting in data grid view
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 2)
            //    {
            //        e.Value = string.Format("{0:dd/MM/yyyy}", (DateTime)e.Value);
            //    }

            //    if (e.ColumnIndex == 3)
            //    {
            //        e.Value = Enum.GetName(typeof(Occupation), e.Value).ToString();
            //    }

            //    if (e.ColumnIndex == 4)
            //    {
            //        e.Value = Enum.GetName(typeof(MaritalStatus), e.Value).ToString();
            //    }

            //    if (e.ColumnIndex == 5)
            //    {
            //        e.Value = Enum.GetName(typeof(HealthStatus), e.Value).ToString();
            //    }

            //    if (e.ColumnIndex == 6)
            //    {
            //        e.Value = Convert.ToDecimal(e.Value) == 0 ? string.Empty : e.Value;
            //    }

            //    if (e.ColumnIndex == 7)
            //    {
            //        e.Value = Convert.ToInt16(e.Value) == 0 ? string.Empty : e.Value;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        /// <summary>
        /// Click event to handle search
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Search_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable data = this.clubMemberService.SearchClubMembers(cmbSearchOccupation.SelectedValue, cmbSearchMaritalStatus.SelectedValue, cmbOperand.GetItemText(cmbOperand.SelectedItem));
            //    this.LoadDataGridView(data);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        /// <summary>
        /// Click event to handle the refresh
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        private void Refresh_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.ResetSearch();
            //    DataTable data = this.clubMemberService.GetAllClubMembers();
            //    this.LoadDataGridView(data);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        /// <summary>
        /// Click event to handle print preview
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void PrintPreview_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.SetupPrinting(false))
            //    {
            //        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            //        printPreviewDialog.Document = this.PrintReport;
            //        printPreviewDialog.ShowDialog();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        /// <summary>
        /// Click event to handle print
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Print_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.SetupPrinting(true))
            //    {
            //        this.PrintReport.Print();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        /// <summary>
        /// Event to handle print page
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //try
            //{
            //    bool hasMorePages = this.dataGridViewPrinter.DrawDataGridView(e.Graphics);

            //    if (hasMorePages == true)
            //    {
            //        e.HasMorePages = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        /// <summary>
        /// Click event to handle the export to excel
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        private void Export_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var table = (DataTable)dataGridViewMembers.DataSource;

            //    Microsoft.Office.Interop.Excel.ApplicationClass excel
            //        = new Microsoft.Office.Interop.Excel.ApplicationClass();

            //    excel.Application.Workbooks.Add(true);

            //    int columnIndex = 0;

            //    foreach (DataColumn col in table.Columns)
            //    {
            //        columnIndex++;
            //        excel.Cells[1, columnIndex] = col.ColumnName;
            //    }

            //    int rowIndex = 0;

            //    foreach (DataRow row in table.Rows)
            //    {
            //        rowIndex++;
            //        columnIndex = 0;
            //        foreach (DataColumn col in table.Columns)
            //        {
            //            columnIndex++;
            //            if (columnIndex == 4 || columnIndex == 5 || columnIndex == 6)
            //            {
            //                if (columnIndex == 4)
            //                {
            //                    excel.Cells[rowIndex + 1, columnIndex]
            //                        = Enum.GetName(typeof(Occupation), row[col.ColumnName]);
            //                }

            //                if (columnIndex == 5)
            //                {
            //                    excel.Cells[rowIndex + 1, columnIndex]
            //                        = Enum.GetName(typeof(MaritalStatus), row[col.ColumnName]);
            //                }

            //                if (columnIndex == 6)
            //                {
            //                    excel.Cells[rowIndex + 1, columnIndex]
            //                        = Enum.GetName(typeof(HealthStatus), row[col.ColumnName]);
            //                }
            //            }
            //            else
            //            {
            //                excel.Cells[rowIndex + 1, columnIndex] = row[col.ColumnName].ToString();
            //            }
            //        }
            //    }

            //    excel.Visible = true;
            //    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
            //    worksheet.Activate();
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        private void dataGridViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int currentRow = dataGridViewMembers.SelectedCells[0].RowIndex;
            //MessageBox.Show("cell content click");
            //try
            //{
            //    string clubMemberId = dataGridViewMembers[0, currentRow].Value.ToString();
            //    memberId = int.Parse(clubMemberId);
            //}
            //catch (Exception ex)
            //{

            //}
        }

        /// <summary>
        /// Click event to update the data
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.ValidateUpdate())
            //    {
            //        ClubMemberModel clubMemberModel = new ClubMemberModel()
            //        {
            //            Id = this.memberId,
            //            Name = txt2Name.Text.Trim(),
            //            DateOfBirth = dt2DateOfBirth.Value,
            //            Occupation = (Occupation)cmb2Occupation.SelectedValue,
            //            HealthStatus = (HealthStatus)cmb2HealthStatus.SelectedValue,
            //            MaritalStatus = (MaritalStatus)cmb2MaritalStatus.SelectedValue,
            //            Salary = txt2Salary.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txt2Salary.Text),
            //            NumberOfChildren = txt2NoOfChildren.Text.Trim() == string.Empty ? 0 : Convert.ToInt16(txt2NoOfChildren.Text)
            //        };

            //        var flag = this.clubMemberService.UpdateClubMember(clubMemberModel);

            //        if (flag)
            //        {
            //            DataTable data = this.clubMemberService.GetAllClubMembers();
            //            this.LoadDataGridView(data);

            //            MessageBox.Show(
            //                Resources.Update_Successful_Message,
            //                Resources.Update_Successful_Message_Title,
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(
            //            this.errorMessage,
            //            Resources.Registration_Error_Message_Title,
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var flag = this.clubMemberService.DeleteClubMember(this.memberId);

            //    if (flag)
            //    {
            //        DataTable data = this.clubMemberService.GetAllClubMembers();
            //        this.LoadDataGridView(data);

            //        MessageBox.Show(
            //            Resources.Delete_Successful_Message,
            //            Resources.Delete_Successful_Message_Title,
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        private void dataGridViewMembers_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;

            //try
            //{
            //    if (dgv.SelectedRows.Count > 0)
            //    {
            //        string clubMemberId = dgv.SelectedRows[0].Cells[0].Value.ToString();
            //        memberId = int.Parse(clubMemberId);

            //        DataRow dataRow = this.clubMemberService.GetClubMemberById(memberId);

            //        txt2Name.Text = dataRow["Name"].ToString();
            //        dt2DateOfBirth.Value = Convert.ToDateTime(dataRow["DateOfBirth"]);
            //        cmb2Occupation.SelectedItem = (Occupation)dataRow["Occupation"];
            //        cmb2MaritalStatus.SelectedItem = (MaritalStatus)dataRow["MaritalStatus"];
            //        cmb2HealthStatus.SelectedItem = (HealthStatus)dataRow["HealthStatus"];
            //        txt2Salary.Text = dataRow["Salary"].ToString() == "0.0000" ? string.Empty : dataRow["Salary"].ToString();
            //        txt2NoOfChildren.Text = dataRow["NumberOfChildren"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowErrorMessage(ex);
            //}
        }

        private void btnSearchN_Click(object sender, EventArgs e)
        {
            if (!Ultils.IsServerConnected(Ultils.GetDBConnection()))
            {
                this.ShowErrorMessage(new Exception("Lỗi kết nối DB"));
                return;
            }
            Console.WriteLine("btnSearchN_Click dpStart: " + dpStart.Value.Date.ToString("yyyy-MM-dd"));
            Console.WriteLine("btnSearchN_Click dpEnd: " + dpEnd.Value.Date.ToString("yyyy-MM-dd"));
            Console.WriteLine("btnSearchN_Click cbStatus: " + cbStatus.SelectedValue);
            List<NGUOI_LX> lstData = NGUOI_LX_DA.getData(dpStart.Value.Date, dpEnd.Value.Date, cbStatus.SelectedValue.ToString(), txtCmnd.Text, LIST_MA_DV);
            

            if (lstData != null && lstData.Count > 0)
            {
                btnCheckAll.Enabled = true;
                btnDeselect.Enabled = true;
                btnExportN.Enabled = true;
                if (cbStatus.SelectedValue.ToString() == "04")
                {
                    btnChangeStatus.Visible = true;
                }
                else
                {
                    btnChangeStatus.Visible = false;
                }

                countCheck = lstData.Count;
                countRecord = lstData.Count;
            }
            else
            {
                btnCheckAll.Enabled = false;
                btnDeselect.Enabled = false;
                btnExportN.Enabled = false;
                btnChangeStatus.Visible = false;
                countCheck = 0;
                countRecord = 0;
            }

            updateSumExport();

            gridThongtin.DataSource = Ultils.ConvertToDataTable(lstData);

            checkAll();
        }

        private void updateSumExport()
        {
            String text = msgSumExport;
            text = text.Replace("%num%", countRecord.ToString());
            text = text.Replace("%select%", countCheck.ToString());
            lbSumSearch.Show();
            lbSumSearch.Text = text;
        }

        private NGUOI_LX convertRowToNGUOI_LX(DataGridViewRow row)
        {
            NGUOI_LX rtn = new NGUOI_LX();
            int i = 2;
            rtn.MADK = row.Cells[i++].Value.ToString();
            rtn.HO_VA_TEN = row.Cells[i++].Value.ToString();
            rtn.NGAY_SINH = row.Cells[i++].Value.ToString();
            rtn.SO_CMT = row.Cells[i++].Value.ToString();
            rtn.NOI_TT = row.Cells[i++].Value.ToString();
            rtn.NOI_CT_MA_DVHC = row.Cells[i++].Value.ToString();
            rtn.NOI_CT = row.Cells[i++].Value.ToString();
            rtn.DV_NHAN_HS = row.Cells[i++].Value.ToString();
            rtn.MA_QUOC_TICH = row.Cells[i++].Value.ToString();
            rtn.TEN_NLX = row.Cells[i++].Value.ToString();
            rtn.HO_DEM_NLX = row.Cells[i++].Value.ToString();
            try
            {
                rtn.NGAY_CAP_CMT = row.Cells[i].Value.ToString();
                //rtn.NGAY_CAP_CMT = DateTime.Parse(row.Cells[i].Value.ToString());
                i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DateTime.Parse Exception  Cells NGAY_CAP_CMT " + row.Cells[i].Value.ToString());
                i++;
            }


            rtn.NOI_TT_MA_DVHC = row.Cells[i++].Value.ToString();
            rtn.NOI_TT_MA_DVQL = row.Cells[i++].Value.ToString();
            rtn.NOI_CT_MA_DVQL = row.Cells[i++].Value.ToString();
            rtn.NOI_CAP_CMT = row.Cells[i++].Value.ToString();
            rtn.GHI_CHU = row.Cells[i++].Value.ToString();
            //rtn.TRANG_THAI = (bool)row.Cells[i++].Value;
            rtn.TRANG_THAI = Int32.Parse(row.Cells[i++].Value.ToString());
            rtn.NGUOI_TAO = row.Cells[i++].Value.ToString();
            rtn.NGUOI_SUA = row.Cells[i++].Value.ToString();

            try
            {
                rtn.NGAY_TAO = row.Cells[i].Value.ToString();
                //rtn.NGAY_TAO = DateTime.Parse(row.Cells[i].Value.ToString());
                i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DateTime.Parse Exception Cells NGAY_TAO " + i + ": " + row.Cells[i].Value.ToString());
                i++;
            }

            try
            {
                rtn.NGAY_SUA = row.Cells[i].Value.ToString();
                //rtn.NGAY_SUA = DateTime.Parse(row.Cells[i].Value.ToString());
                i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DateTime.Parse Exception Cells NGAY_SUA " + i + ": " + row.Cells[i].Value.ToString());
                i++;
            }
            //rtn.NGAY_TAO = DateTime.Parse(row.Cells[i++].Value.ToString());
            //rtn.NGAY_SUA = DateTime.Parse(row.Cells[i++].Value.ToString());
            rtn.GIOI_TINH = row.Cells[i++].Value.ToString();
            rtn.HO_VA_TEN_IN = row.Cells[i++].Value.ToString();
            rtn.SO_CMND_CU = row.Cells[i++].Value.ToString();
            return rtn;
        }

        private void btnExportN_Click(object sender, EventArgs e)
        {
            if (!Ultils.IsServerConnected(Ultils.GetDBConnection()))
            {
                this.ShowErrorMessage(new Exception("Lỗi kết nối DB"));
                return;
            }

            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "XML Files (*.xml)|*.xml";

            if (dlgSave.ShowDialog() != DialogResult.OK)
                return;
            string pathExport = dlgSave.FileName;

            //Export
            List<NGUOI_LX> listExport = new List<NGUOI_LX>();
            foreach (DataGridViewRow row in gridThongtin.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = (chk.Value == null ? false : (bool)chk.Value);

                if ((bool)chk.Value == true)
                {
                    listExport.Add(convertRowToNGUOI_LX(row));
                }
            }

            List<NGUOILX_HOSO> lstHoso = NGUOILX_HOSO_DA.getData(listExport);
            List<GIAY_TO> lstGiayTo = GIAY_TO_DA.getData(listExport);
            Ultils.exportXml(pathExport, listExport, lstHoso, lstGiayTo);

            //Cap nhat trang thai
            String updateStatus = NGUOILX_HOSO_DA.updateStatusList(listExport, NGUOILX_HOSO.TT_DAKETXUAT);
            bool checkUpdate = false;
            try
            {
                if (updateStatus == "")
                {
                    checkUpdate = true;
                }
                else
                {
                    checkUpdate = Int32.Parse(updateStatus) > 0;
                }
            }
            catch (FormatException pex)
            {
                Console.WriteLine("Loi FormatException: " + pex.Message + " - " + updateStatus);
                //Loi
                MessageBox.Show("Xuất thành công file không thành công do cập nhật trạng thái thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!checkUpdate)
            {
                MessageBox.Show("Xuất thành công file không thành công do cập nhật trạng thái thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Xong cap nhat trang thai

            if (Ultils.getConfig("openExport") == "1")
            {
                DialogResult d = MessageBox.Show("Xuất thành công file: " + pathExport.Substring(pathExport.LastIndexOf('\\') + 1), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.Yes || d == DialogResult.OK)
                {
                    pathExport = pathExport.Substring(0, pathExport.LastIndexOf('\\'));
                    Console.WriteLine("Ultils.OpenFolder : " + pathExport);
                    Ultils.OpenFolder(pathExport);
                }
            }
            else
            {
                MessageBox.Show("Xuất thành công file: " + pathExport, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            checkAll();
        }

        private void checkAll()
        {
            foreach (DataGridViewRow row in gridThongtin.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = true;
            }

            //
            countCheck = countRecord;
            updateSumExport();
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridThongtin.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = false;
            }
            countCheck = 0;
            updateSumExport();
        }

        private void txtPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtPath.Text = openFileDialog1.FileName;
            if (txtPath.Text.Length > 0)
            {
                //Convert xml thanh object
                HEADER rtn = Ultils.Deserialize(txtPath.Text);

                BODY bODY = rtn.BODY;

                //View Grid
                List<NGUOI_LX> lstData = bODY.ListNguoiLx;
                int i = 1;
                foreach (NGUOI_LX obj in lstData)
                {
                    obj.STT = i++;
                }
                gridData.DataSource = Ultils.ConvertToDataTable(lstData);

                //
                btnImport.Enabled = true;

                txtImportSuccess.Text = "0/" + lstData.Count;
            }
            else
            {
                gridData.DataSource = null;
                btnImport.Enabled = false;
            }
        }


        int importSuccess = 0;
        private void btnImport_Click(object sender, EventArgs e)
        {
            //Tao thu muc import
            System.IO.Directory.CreateDirectory(Ultils.getConfigInDB("IMG_PATH_VPDK_SOGTVT"));

            if (txtPath.Text == null || txtPath.Text.Trim().Length <= 0)
            {
                DialogResult d = MessageBox.Show("Vui lòng chọn file để import!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes || d == DialogResult.OK)
                {
                    openFileDialog1.ShowDialog();
                }
                return;
            }

            if (!Ultils.IsServerConnected(Ultils.GetDBConnectionImport()))
            {
                this.ShowErrorMessage(new Exception("Lỗi kết nối DB"));
                return;
            }


            //Convert xml thanh object
            HEADER rtn = Ultils.Deserialize(txtPath.Text);

            BODY bODY = rtn.BODY;


            //Tao thu muc cho ListNguoiLxHs
            Dictionary<String, String> myDictionary = new Dictionary<string, string>();
            String NGAYTHUNHANANH = "";
            foreach (NGUOILX_HOSO obj in bODY.ListNguoiLxHs)
            {
                if (obj.DUONGDANANH != null && obj.DUONGDANANH.Trim().Length > 0)
                {
                    if (obj.NGAYTHUNHANANH != "")
                    {
                        try
                        {
                            NGAYTHUNHANANH = DateTime.Parse(obj.NGAYTHUNHANANH).ToString(Ultils.FORMAT_DATE_FOLDER);
                            if (!myDictionary.ContainsKey(NGAYTHUNHANANH))
                            {
                                myDictionary.Add(NGAYTHUNHANANH, NGAYTHUNHANANH);
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
            }



            ////DEcode anh jp2
            String message = Ultils.importHosoJp2(bODY.ListNguoiLxHs);

            if (message == "")
            {
                importSuccess = 0;
                message = importTuanTu(bODY.ListNguoiLx, bODY.ListNguoiLxHs, bODY.ListGiayTo, ref importSuccess);

                //Import nhanh
                //message = Ultils.importDbWithCommit(bODY.ListNguoiLx, bODY.ListNguoiLxHs, bODY.ListGiayTo);
                if (message == "")
                {
                    MessageBox.Show("Import thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtImportSuccess.Text = importSuccess.ToString() + "/" + bODY.ListNguoiLx.Count;
                }
                else if (message == "cancel")
                {
                    txtImportSuccess.Text = importSuccess.ToString() + "/" + bODY.ListNguoiLx.Count;
                }
                else
                {
                    MessageBox.Show("Import không thành công: " + message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImportSuccess.Text = "0" + "/" + bODY.ListNguoiLx.Count;
                }
            }
        }

        private string importTuanTu(List<NGUOI_LX> ListNguoiLx, List<NGUOILX_HOSO> ListNguoiLxHs, List<GIAY_TO> ListGiayTo, ref int importSuccess)
        {
            List<NGUOILX_HOSO> ListNguoiLxHsTmp = null;
            List<GIAY_TO> ListGiayToTmp = null;


            String mesage = "";
            foreach (NGUOI_LX nguoilx in ListNguoiLx)
            {
                try
                {
                    ListNguoiLxHsTmp = ListNguoiLxHs.Where(x => x.MADK == nguoilx.MADK).ToList();
                    ListGiayToTmp = ListGiayTo.Where(x => x.MADK == nguoilx.MADK).ToList();

                    mesage = Ultils.importNguoiLxeWithCommit(nguoilx, ListNguoiLxHsTmp, ListGiayToTmp);

                    //Remove 
                    ListNguoiLxHs.RemoveAll(x => x.MADK == nguoilx.MADK);
                    ListGiayTo.RemoveAll(x => x.MADK == nguoilx.MADK);

                    if (mesage != null && mesage.Length > 0 && mesage.Contains("constraint 'PK_NguoiLX'"))
                    {
                        DialogResult d = MessageBox.Show("Mã ĐK " + nguoilx.MADK + " đã tồn tại. Bạn muốn thay đổi mã ĐK?", "Thay đổi Mã ĐK", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (d == DialogResult.Yes || d == DialogResult.OK)
                        {
                            catchImportNguoiLxe(nguoilx, ListNguoiLxHsTmp, ListGiayToTmp, ref importSuccess);
                        }
                        else if (d == DialogResult.No || d == DialogResult.None)
                        {
                            continue;
                        }
                        else if (d == DialogResult.Cancel)
                        {
                            return "cancel";
                        }
                    }
                    else
                        importSuccess++;
                    Console.WriteLine("------NGUOI_LX: " + nguoilx.MADK + " - -ListNguoiLxHs: " + ListNguoiLxHs.Count + " - ListGiayTo: " + ListGiayTo.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
            }

            if (ListNguoiLxHs.Count > 0)
            {
                Console.WriteLine("------WTF ListNguoiLxHs > 0 " + ListNguoiLxHs.Count);
                //Import nguoi lxhs
                foreach (NGUOILX_HOSO obj in ListNguoiLxHs)
                {
                    NGUOILX_HOSO_DA.insertData(obj);
                }

            }
            if (ListGiayTo.Count > 0)
            {
                Console.WriteLine("------WTF ListGiayTo > 0 " + ListGiayTo.Count);
                //Import ListGiayTo
                foreach (GIAY_TO obj in ListGiayTo)
                {
                    GIAY_TO_DA.insertData(obj);
                }
            }
            return "";
        }

        private void catchImportNguoiLxe(NGUOI_LX NguoiLx, List<NGUOILX_HOSO> ListNguoiLxHs, List<GIAY_TO> ListGiayTo, ref int importSuccess)
        {
            try
            {
                String newMaDK = NguoiLx.MADK;
                DialogResult dg = Ultils.InputBox("Cập nhật Mã ĐK", "Mã ĐK mới", ref newMaDK);
                if (dg == DialogResult.Yes || dg == DialogResult.OK)
                {
                    NguoiLx.MADK = newMaDK;
                    Console.WriteLine("------NguoiLx.MADK: " + NguoiLx.MADK);

                    foreach (NGUOILX_HOSO obj in ListNguoiLxHs)
                    {
                        obj.MADK = newMaDK;
                    }
                    foreach (GIAY_TO obj in ListGiayTo)
                    {
                        obj.MADK = newMaDK;
                    }

                    //Rename anh cu
                    Ultils.renameAnhHosoJp2(ListNguoiLxHs);

                    //Import lai
                    string mesage = Ultils.importNguoiLxeWithCommit(NguoiLx, ListNguoiLxHs, ListGiayTo);
                    if (mesage != null && mesage.Length > 0 && mesage.Contains("constraint 'PK_NguoiLX'"))
                    {
                        DialogResult d = MessageBox.Show("importNguoiLxeWithCommit: " + mesage, "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (d == DialogResult.Yes || d == DialogResult.OK)
                        {
                            catchImportNguoiLxe(NguoiLx, ListNguoiLxHs, ListGiayTo, ref importSuccess);
                        }
                    }
                    else
                        importSuccess++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void insertBulkData(List<NGUOI_LX> ListNguoiLx, List<NGUOILX_HOSO> ListNguoiLxHs, List<GIAY_TO> ListGiayTo)
        {
            List<NGUOI_LX_DB> ListNguoiLxDb = new List<NGUOI_LX_DB>(ListNguoiLx.Count);
            List<NGUOILX_HOSO_DB> ListNguoiLxHsDb = new List<NGUOILX_HOSO_DB>(ListNguoiLxHs.Count);
            List<GIAY_TO_DB> ListGiayToDb = new List<GIAY_TO_DB>(ListGiayTo.Count);

            foreach (NGUOI_LX obj in ListNguoiLx)
            {
                ListNguoiLxDb.Add(NGUOI_LX_DB.copyData(obj));
            }
            Ultils.testImport(ListNguoiLxDb, "NguoiLX");

            //NGUOILX_HOSO_DB
            foreach (NGUOILX_HOSO obj in ListNguoiLxHs)
            {
                ListNguoiLxHsDb.Add(NGUOILX_HOSO_DB.copyData(obj));
            }
            Ultils.testImport(ListNguoiLxHsDb, "NguoiLX_HoSo");

            //copyData
            foreach (GIAY_TO obj in ListGiayTo)
            {
                ListGiayToDb.Add(GIAY_TO_DB.copyData(obj));
            }
            Ultils.testImport(ListGiayToDb, "NguoiLXHS_GiayTo");
        }

        //For tesst
        String encode = "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";
        private void button1_Click(object sender, EventArgs e)
        {
            //String enc = Ultils.tesst(@"F:\Project\CSharp\LicenseRegister\img\relax.jp2");
            //String enc = Ultils.tesst(@"F:\Project\CSharp\LicenseRegister\GPLX.App.Desktop\bin\Debug\tesstfile.jp2");
            string tessencode = Ultils.encodeJp2(@"D:\var\lib\decodeJp2.jp2");
            Console.WriteLine("--------------enc: " + encode.Length);
            Console.WriteLine("--------------tessencode: " + tessencode.Length);
            Console.WriteLine("--------------encode 1: " + encode);
            Console.WriteLine("--------------encode 2: " + tessencode);
            Console.WriteLine("-------------- Ultils.tesst(): " + encode.Equals(tessencode));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filepath = Ultils.getConfig("pathImport") + "\\" + DateTime.Now.ToString(Ultils.FORMAT_DATE_FOLDER);
            System.IO.Directory.CreateDirectory(filepath);
            Console.WriteLine("-------------- Ultils.decodeJp2(): " + Ultils.decodeJp2(filepath, "decodeJp2.jp2", encode));

            Console.WriteLine("-------------- Ultils.done(): ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            encode = Ultils.encodeJp2(@"D:\var\lib\decodeJp2.jp2");

            Console.WriteLine("-------------- button3_Click .done(): ");
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (!Ultils.IsServerConnected(Ultils.GetDBConnection()))
            {
                this.ShowErrorMessage(new Exception("Lỗi kết nối DB"));
                return;
            }

            //Export
            List<NGUOI_LX> listExport = new List<NGUOI_LX>();
            foreach (DataGridViewRow row in gridThongtin.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = (chk.Value == null ? false : (bool)chk.Value);

                if ((bool)chk.Value == true)
                {
                    listExport.Add(convertRowToNGUOI_LX(row));
                }
            }

            String updateStatus = NGUOILX_HOSO_DA.updateStatusList(listExport, NGUOILX_HOSO.TT_CHUAKETXUAT);

            try
            {
                if (updateStatus == "" || Int32.Parse(updateStatus) > 0)
                {
                    String msg = "";
                    if (updateStatus == "")
                    {
                        msg = "Cập nhật trạng thái chưa kết xuất thành công!";
                    }
                    else
                    {
                        msg = "Cập nhật trạng thái chưa kết xuất thành công " + updateStatus + " bản ghi";
                    }
                    DialogResult d = MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException pex)
            {
                //Loi
                MessageBox.Show("Cập nhật trạng thái chưa kết xuất không thành công", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("cbStatus.SelectedValue.ToString(): " + cbStatus.SelectedValue.ToString());
            //if (cbStatus.SelectedValue.ToString() == "04")
            //{
            //    btnChangeStatus.Visible = true;
            //}
            //else
            //{
            //    btnChangeStatus.Visible = false;
            //}
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            // Set the Format type and the CustomFormat string.
            dpStart.Format = DateTimePickerFormat.Custom;
            dpStart.CustomFormat = "dd/MM/yyyy";

            dpEnd.Format = DateTimePickerFormat.Custom;
            dpEnd.CustomFormat = "dd/MM/yyyy";

            //
            if (TYPE_EXPORT)
                tab.TabPages.Remove(tabImport);
            else
                tab.TabPages.Remove(tabExport);
        }

        public static String LIST_MA_DV = "'061', '062', '063', '064', '065', '066', '067', '068', '069', '0610', '041', '042', '043', '044', '045', '046', '047', '048', '049', '0410'";
        private static bool TYPE_EXPORT = true;
        private String msgSumExport = "Đã chọn %select% trong số %num% hồ sơ";

        private int countCheck = 0;
        private int countRecord = 0;
        private void gridThongtin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cbColumn.Index && e.RowIndex != -1)
            {
                gridThongtin.CommitEdit(DataGridViewDataErrorContexts.Commit);
                // Handle checkbox state change here
                Boolean Value = Convert.ToBoolean(gridThongtin.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                if (Value)
                    countCheck++;
                else
                    countCheck--;
                updateSumExport();
            }
        }
    }
}
