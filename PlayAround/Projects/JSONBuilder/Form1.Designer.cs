namespace JSONBuilder
{
    partial class frm_Main
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
            this.tv_JSONStructure = new System.Windows.Forms.TreeView();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_zone_height = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_zone_width = new System.Windows.Forms.TextBox();
            this.lbl_zone_width = new System.Windows.Forms.Label();
            this.txt_zone_name = new System.Windows.Forms.TextBox();
            this.lbl_zone_name = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.txt_zone_description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_zone_textureID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_zone_update = new System.Windows.Forms.Button();
            this.txt_npc_textureID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_npc_position = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_npc_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_npc_dialogue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_obj_textureID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_obj_position = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_obj_name = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_exit_zoneID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_exit_position = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_exit_name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_exit_textureID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_npc_update = new System.Windows.Forms.Button();
            this.btn_obj_update = new System.Windows.Forms.Button();
            this.btn_exit_update = new System.Windows.Forms.Button();
            this.tc_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_JSONStructure
            // 
            this.tv_JSONStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_JSONStructure.Location = new System.Drawing.Point(10, 10);
            this.tv_JSONStructure.Name = "tv_JSONStructure";
            this.tv_JSONStructure.Size = new System.Drawing.Size(210, 520);
            this.tv_JSONStructure.TabIndex = 0;
            this.tv_JSONStructure.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_JSONStructure_NodeMouseClick);
            // 
            // tc_Main
            // 
            this.tc_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_Main.Controls.Add(this.tabPage1);
            this.tc_Main.Controls.Add(this.tabPage2);
            this.tc_Main.Controls.Add(this.tabPage3);
            this.tc_Main.Controls.Add(this.tabPage4);
            this.tc_Main.Location = new System.Drawing.Point(240, 10);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(430, 540);
            this.tc_Main.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_zone_update);
            this.tabPage1.Controls.Add(this.txt_zone_textureID);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_zone_description);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_zone_height);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_zone_width);
            this.tabPage1.Controls.Add(this.lbl_zone_width);
            this.tabPage1.Controls.Add(this.txt_zone_name);
            this.tabPage1.Controls.Add(this.lbl_zone_name);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(422, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Zone Properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_zone_height
            // 
            this.txt_zone_height.Location = new System.Drawing.Point(325, 40);
            this.txt_zone_height.Name = "txt_zone_height";
            this.txt_zone_height.Size = new System.Drawing.Size(75, 20);
            this.txt_zone_height.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(240, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zone Height:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_zone_width
            // 
            this.txt_zone_width.Location = new System.Drawing.Point(100, 40);
            this.txt_zone_width.Name = "txt_zone_width";
            this.txt_zone_width.Size = new System.Drawing.Size(75, 20);
            this.txt_zone_width.TabIndex = 3;
            // 
            // lbl_zone_width
            // 
            this.lbl_zone_width.Location = new System.Drawing.Point(15, 40);
            this.lbl_zone_width.Name = "lbl_zone_width";
            this.lbl_zone_width.Size = new System.Drawing.Size(79, 20);
            this.lbl_zone_width.TabIndex = 2;
            this.lbl_zone_width.Text = "Zone Width:";
            this.lbl_zone_width.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_zone_name
            // 
            this.txt_zone_name.Location = new System.Drawing.Point(100, 15);
            this.txt_zone_name.Name = "txt_zone_name";
            this.txt_zone_name.Size = new System.Drawing.Size(300, 20);
            this.txt_zone_name.TabIndex = 1;
            // 
            // lbl_zone_name
            // 
            this.lbl_zone_name.Location = new System.Drawing.Point(15, 15);
            this.lbl_zone_name.Name = "lbl_zone_name";
            this.lbl_zone_name.Size = new System.Drawing.Size(79, 20);
            this.lbl_zone_name.TabIndex = 0;
            this.lbl_zone_name.Text = "Name:";
            this.lbl_zone_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_npc_update);
            this.tabPage2.Controls.Add(this.txt_npc_dialogue);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txt_npc_textureID);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txt_npc_position);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txt_npc_name);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(422, 514);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "NPC Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_obj_update);
            this.tabPage3.Controls.Add(this.txt_obj_textureID);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txt_obj_position);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.txt_obj_name);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(422, 514);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Object Properties";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btn_exit_update);
            this.tabPage4.Controls.Add(this.txt_exit_textureID);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.txt_exit_zoneID);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.txt_exit_position);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.txt_exit_name);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(422, 514);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Exit Properties";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_import
            // 
            this.btn_import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_import.Location = new System.Drawing.Point(10, 535);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(80, 24);
            this.btn_import.TabIndex = 2;
            this.btn_import.Text = "Import JSON";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.Location = new System.Drawing.Point(140, 535);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(80, 24);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "Export JSON";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // txt_zone_description
            // 
            this.txt_zone_description.Location = new System.Drawing.Point(100, 65);
            this.txt_zone_description.Multiline = true;
            this.txt_zone_description.Name = "txt_zone_description";
            this.txt_zone_description.Size = new System.Drawing.Size(300, 80);
            this.txt_zone_description.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_zone_textureID
            // 
            this.txt_zone_textureID.Location = new System.Drawing.Point(100, 150);
            this.txt_zone_textureID.Name = "txt_zone_textureID";
            this.txt_zone_textureID.Size = new System.Drawing.Size(25, 20);
            this.txt_zone_textureID.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "TextureID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_zone_update
            // 
            this.btn_zone_update.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_zone_update.Location = new System.Drawing.Point(175, 485);
            this.btn_zone_update.Name = "btn_zone_update";
            this.btn_zone_update.Size = new System.Drawing.Size(75, 23);
            this.btn_zone_update.TabIndex = 10;
            this.btn_zone_update.Text = "Update";
            this.btn_zone_update.UseVisualStyleBackColor = true;
            this.btn_zone_update.Click += new System.EventHandler(this.btn_zone_update_Click);
            // 
            // txt_npc_textureID
            // 
            this.txt_npc_textureID.Location = new System.Drawing.Point(100, 150);
            this.txt_npc_textureID.Name = "txt_npc_textureID";
            this.txt_npc_textureID.Size = new System.Drawing.Size(25, 20);
            this.txt_npc_textureID.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "TextureID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_npc_position
            // 
            this.txt_npc_position.Location = new System.Drawing.Point(100, 40);
            this.txt_npc_position.Name = "txt_npc_position";
            this.txt_npc_position.Size = new System.Drawing.Size(125, 20);
            this.txt_npc_position.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Position:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_npc_name
            // 
            this.txt_npc_name.Location = new System.Drawing.Point(100, 15);
            this.txt_npc_name.Name = "txt_npc_name";
            this.txt_npc_name.Size = new System.Drawing.Size(300, 20);
            this.txt_npc_name.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_npc_dialogue
            // 
            this.txt_npc_dialogue.Location = new System.Drawing.Point(100, 63);
            this.txt_npc_dialogue.Multiline = true;
            this.txt_npc_dialogue.Name = "txt_npc_dialogue";
            this.txt_npc_dialogue.Size = new System.Drawing.Size(300, 80);
            this.txt_npc_dialogue.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(15, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 35);
            this.label13.TabIndex = 16;
            this.label13.Text = "Default Dialogue:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_obj_textureID
            // 
            this.txt_obj_textureID.Location = new System.Drawing.Point(100, 65);
            this.txt_obj_textureID.Name = "txt_obj_textureID";
            this.txt_obj_textureID.Size = new System.Drawing.Size(25, 20);
            this.txt_obj_textureID.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(15, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "TextureID:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_obj_position
            // 
            this.txt_obj_position.Location = new System.Drawing.Point(100, 40);
            this.txt_obj_position.Name = "txt_obj_position";
            this.txt_obj_position.Size = new System.Drawing.Size(125, 20);
            this.txt_obj_position.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(15, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Position:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_obj_name
            // 
            this.txt_obj_name.Location = new System.Drawing.Point(100, 15);
            this.txt_obj_name.Name = "txt_obj_name";
            this.txt_obj_name.Size = new System.Drawing.Size(300, 20);
            this.txt_obj_name.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(15, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 20);
            this.label14.TabIndex = 18;
            this.label14.Text = "Name:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_exit_zoneID
            // 
            this.txt_exit_zoneID.Location = new System.Drawing.Point(100, 65);
            this.txt_exit_zoneID.Name = "txt_exit_zoneID";
            this.txt_exit_zoneID.Size = new System.Drawing.Size(25, 20);
            this.txt_exit_zoneID.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "ZoneID:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_exit_position
            // 
            this.txt_exit_position.Location = new System.Drawing.Point(100, 40);
            this.txt_exit_position.Name = "txt_exit_position";
            this.txt_exit_position.Size = new System.Drawing.Size(125, 20);
            this.txt_exit_position.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(15, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Position:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_exit_name
            // 
            this.txt_exit_name.Location = new System.Drawing.Point(100, 15);
            this.txt_exit_name.Name = "txt_exit_name";
            this.txt_exit_name.Size = new System.Drawing.Size(300, 20);
            this.txt_exit_name.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(15, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Name:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_exit_textureID
            // 
            this.txt_exit_textureID.Location = new System.Drawing.Point(100, 90);
            this.txt_exit_textureID.Name = "txt_exit_textureID";
            this.txt_exit_textureID.Size = new System.Drawing.Size(25, 20);
            this.txt_exit_textureID.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(15, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "TextureID:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_npc_update
            // 
            this.btn_npc_update.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_npc_update.Location = new System.Drawing.Point(175, 485);
            this.btn_npc_update.Name = "btn_npc_update";
            this.btn_npc_update.Size = new System.Drawing.Size(75, 23);
            this.btn_npc_update.TabIndex = 18;
            this.btn_npc_update.Text = "Update";
            this.btn_npc_update.UseVisualStyleBackColor = true;
            this.btn_npc_update.Click += new System.EventHandler(this.btn_npc_update_Click);
            // 
            // btn_obj_update
            // 
            this.btn_obj_update.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_obj_update.Location = new System.Drawing.Point(175, 485);
            this.btn_obj_update.Name = "btn_obj_update";
            this.btn_obj_update.Size = new System.Drawing.Size(75, 23);
            this.btn_obj_update.TabIndex = 24;
            this.btn_obj_update.Text = "Update";
            this.btn_obj_update.UseVisualStyleBackColor = true;
            this.btn_obj_update.Click += new System.EventHandler(this.btn_obj_update_Click);
            // 
            // btn_exit_update
            // 
            this.btn_exit_update.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_exit_update.Location = new System.Drawing.Point(175, 485);
            this.btn_exit_update.Name = "btn_exit_update";
            this.btn_exit_update.Size = new System.Drawing.Size(75, 23);
            this.btn_exit_update.TabIndex = 32;
            this.btn_exit_update.Text = "Update";
            this.btn_exit_update.UseVisualStyleBackColor = true;
            this.btn_exit_update.Click += new System.EventHandler(this.btn_exit_update_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.tc_Main);
            this.Controls.Add(this.tv_JSONStructure);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "frm_Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSON Builder";
            this.tc_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_JSONStructure;
        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.TextBox txt_zone_name;
        private System.Windows.Forms.Label lbl_zone_name;
        private System.Windows.Forms.TextBox txt_zone_height;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_zone_width;
        private System.Windows.Forms.Label lbl_zone_width;
        private System.Windows.Forms.TextBox txt_zone_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_zone_textureID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_zone_update;
        private System.Windows.Forms.TextBox txt_npc_dialogue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_npc_textureID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_npc_position;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_npc_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_obj_textureID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_obj_position;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_obj_name;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_exit_textureID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_exit_zoneID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_exit_position;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_exit_name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_npc_update;
        private System.Windows.Forms.Button btn_obj_update;
        private System.Windows.Forms.Button btn_exit_update;
    }
}

