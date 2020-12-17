namespace _6_laba_OOP
{
    partial class laba6
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(laba6));
            this.panel_drawing = new System.Windows.Forms.Panel();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.drawellipse = new System.Windows.Forms.ToolStripButton();
            this.drawsquare = new System.Windows.Forms.ToolStripButton();
            this.drawrhomb = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_drawing
            // 
            this.panel_drawing.BackColor = System.Drawing.SystemColors.Info;
            this.panel_drawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_drawing.Location = new System.Drawing.Point(13, 13);
            this.panel_drawing.Name = "panel_drawing";
            this.panel_drawing.Size = new System.Drawing.Size(639, 450);
            this.panel_drawing.TabIndex = 0;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 451);
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.Dock = System.Windows.Forms.DockStyle.None;
            this.menu.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawellipse,
            this.drawsquare,
            this.drawrhomb});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menu.Location = new System.Drawing.Point(661, 83);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(120, 118);
            this.menu.TabIndex = 0;
            this.menu.Text = "Меню";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(658, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите фигуру, которую хотите отобразить на панели";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // drawellipse
            // 
            this.drawellipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawellipse.Image = global::_6_laba_OOP.Properties.Resources.Ellipse;
            this.drawellipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawellipse.Name = "drawellipse";
            this.drawellipse.Size = new System.Drawing.Size(54, 54);
            this.drawellipse.Text = "Круг";
            this.drawellipse.Click += new System.EventHandler(this.drawellipse_Click);
            // 
            // drawsquare
            // 
            this.drawsquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawsquare.Image = ((System.Drawing.Image)(resources.GetObject("drawsquare.Image")));
            this.drawsquare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawsquare.Name = "drawsquare";
            this.drawsquare.Size = new System.Drawing.Size(54, 54);
            this.drawsquare.Text = "Квадрат";
            // 
            // drawrhomb
            // 
            this.drawrhomb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawrhomb.Image = global::_6_laba_OOP.Properties.Resources.Rhomb;
            this.drawrhomb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawrhomb.Name = "drawrhomb";
            this.drawrhomb.Size = new System.Drawing.Size(54, 54);
            this.drawrhomb.Text = "Ромб";
            this.drawrhomb.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // laba6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.panel_drawing);
            this.Name = "laba6";
            this.Text = "6 Laba OOP";
            this.TopMost = true;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_drawing;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton drawellipse;
        private System.Windows.Forms.ToolStripButton drawsquare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripButton drawrhomb;
    }
}

