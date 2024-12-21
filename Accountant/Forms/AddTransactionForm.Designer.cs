namespace Accountant
{
    partial class AddTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTransactionForm));
            this.dateEditTransaction = new DevExpress.XtraEditors.DateEdit();
            this.textEditCustomerName = new System.Windows.Forms.TextBox();
            this.spinEditAmount = new DevExpress.XtraEditors.SpinEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTransaction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTransaction.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEditTransaction
            // 
            this.dateEditTransaction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateEditTransaction.EditValue = "";
            this.dateEditTransaction.Location = new System.Drawing.Point(33, 92);
            this.dateEditTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.dateEditTransaction.Name = "dateEditTransaction";
            this.dateEditTransaction.Properties.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditTransaction.Properties.Appearance.Options.UseFont = true;
            this.dateEditTransaction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTransaction.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTransaction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateEditTransaction.Size = new System.Drawing.Size(406, 32);
            this.dateEditTransaction.TabIndex = 0;
            // 
            // textEditCustomerName
            // 
            this.textEditCustomerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEditCustomerName.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditCustomerName.Location = new System.Drawing.Point(33, 182);
            this.textEditCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.textEditCustomerName.Name = "textEditCustomerName";
            this.textEditCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditCustomerName.Size = new System.Drawing.Size(406, 33);
            this.textEditCustomerName.TabIndex = 1;
            // 
            // spinEditAmount
            // 
            this.spinEditAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinEditAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditAmount.Location = new System.Drawing.Point(33, 273);
            this.spinEditAmount.Margin = new System.Windows.Forms.Padding(2);
            this.spinEditAmount.Name = "spinEditAmount";
            this.spinEditAmount.Properties.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditAmount.Properties.Appearance.Options.UseFont = true;
            this.spinEditAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.spinEditAmount.Size = new System.Drawing.Size(406, 32);
            this.spinEditAmount.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(33, 377);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(125, 56);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "الغاء";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(314, 377);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(125, 56);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(211, 50);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 26);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "التاريخ";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(189, 140);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 26);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "اسم العميل";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(211, 231);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 26);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "المبلغ";
            // 
            // AddTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 483);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.spinEditAmount);
            this.Controls.Add(this.textEditCustomerName);
            this.Controls.Add(this.dateEditTransaction);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTransactionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة سجل جديد";
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTransaction.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTransaction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAmount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEditTransaction;
        private System.Windows.Forms.TextBox textEditCustomerName;
        private DevExpress.XtraEditors.SpinEdit spinEditAmount;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}