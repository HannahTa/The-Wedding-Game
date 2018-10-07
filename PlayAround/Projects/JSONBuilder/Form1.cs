using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSONBuilder
{
    public partial class frm_Main : Form
    {
        // TODO: 
        //  - Write code so can export said JSON file. 

        private List<TabPage> tabs = new List<TabPage>();
        private Zone zone;
        private NPC npc;
        private Object obj;
        private Exit exit;
        

        public frm_Main()
        {
            InitializeComponent();
            // Remove tabs (well... store them)
            foreach(TabPage page in tc_Main.TabPages)
            {
                tabs.Add(page);
            }
            // Clean screen
            tc_Main.TabPages.Clear();
        }

        public void LoadTab(int index)
        {
            tc_Main.TabPages.Clear();
            tc_Main.TabPages.Add(tabs[index]);
        }

        public TreeNode ZoneToTree()
        {
            // Clear new Nodes
            tv_JSONStructure.Nodes.Clear();
            // Create new Nodes to add
            TreeNode parent = new TreeNode
            {
                Text = zone.Id.ToString() + " : " + zone.Name
            };
            // NPCs
            TreeNode child = new TreeNode
            {
                Text = "NPCs"
            };
            parent.Nodes.Add(child);
            foreach (NPC obj in zone.NPCs)
            {
                TreeNode tmp = new TreeNode
                {
                    Text = obj.Id.ToString() + ":" + obj.Name
                };
                child.Nodes.Add(tmp);
            }
            // Objects
            child = new TreeNode
            {
                Text = "Objects"
            };
            parent.Nodes.Add(child);
            foreach(Object obj in zone.Objects)
            {
                TreeNode tmp = new TreeNode
                {
                    Text = obj.Id.ToString() + ":" + obj.Name
                };
                child.Nodes.Add(tmp);
            }
            // Exits
            child = new TreeNode
            {
                Text = "Exits"
            };
            parent.Nodes.Add(child);
            foreach (Exit obj in zone.Exits)
            {
                TreeNode tmp = new TreeNode
                {
                    Text = obj.Id.ToString() + ":" + obj.Name
                };
                child.Nodes.Add(tmp);
            }
            return parent;
        }

        private void tv_JSONStructure_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selected = e.Node;
            if (selected.Text.Contains(":"))
            {
                if(selected.Parent == null)
                {
                    // Fill relevent boxes
                    txt_zone_name.Text = zone.Name;
                    txt_zone_width.Text = zone.Width.ToString();
                    txt_zone_height.Text = zone.Height.ToString();
                    txt_zone_description.Text = zone.Description;
                    txt_zone_textureID.Text = zone.TextureID.ToString();
                    // Load tab
                    LoadTab(0);
                }
                else
                {
                    string id = selected.Text.Split(':')[0];
                    string name = selected.Text.Split(':')[1];
                    switch (selected.Parent.Text.ToString())
                    {
                        case "NPCs":
                            // Get object
                            npc = zone.GetNPC(id, name);
                            // Fill relevent boxes
                            txt_npc_name.Text = npc.Name;
                            txt_npc_position.Text = npc.Position;
                            txt_npc_dialogue.Text = npc.DefaultDialogue;
                            txt_npc_textureID.Text = npc.TextureId.ToString();
                            // Load tab
                            LoadTab(1);
                            break;
                        case "Objects":
                            // Get object
                            obj = zone.GetObject(id, name);
                            // Fill relevent boxes
                            txt_obj_name.Text = obj.Name;
                            txt_obj_position.Text = obj.Position;
                            txt_obj_textureID.Text = obj.TextureId.ToString();
                            // Load tab
                            LoadTab(2);
                            break;
                        case "Exits":
                            // Get object
                            exit = zone.GetExit(id, name);
                            // Fill relevent boxes
                            txt_exit_name.Text = exit.Name;
                            txt_exit_position.Text = exit.Position;
                            txt_exit_zoneID.Text = exit.ZoneId.ToString();
                            txt_exit_textureID.Text = exit.TextureId.ToString();
                            // Load tab
                            LoadTab(3);
                            break;
                    }
                }
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is currently only configured for Zone files. This will expand in the future.");
            // FindForm and Open JSON File
            OpenFileDialog fd = new OpenFileDialog()
            {
                Filter = "Json files (*.json)|*.json"
            };
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tc_Main.TabPages.Clear();
                // Load into object!
                try
                {
                    zone = JsonConvert.DeserializeObject<Zone>(File.ReadAllText(fd.FileName));
                    tv_JSONStructure.Nodes.Add(ZoneToTree());
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to import file! " + ex.Message);
                }
                
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            // Save as export!
            SaveFileDialog sd = new SaveFileDialog
            {
                Filter = "Json files (*.json)|*.json"
            };
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    var zoneData = JsonConvert.SerializeObject(zone, Formatting.Indented);
                    File.WriteAllText(sd.FileName, zoneData);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to export file! " + ex.Message);
                }
            }
        }

        private void btn_zone_update_Click(object sender, EventArgs e)
        {
            zone.Name = txt_zone_name.Text;
            zone.Width = int.Parse(txt_zone_width.Text);
            zone.Height = int.Parse(txt_zone_height.Text);
            zone.Description = txt_zone_description.Text;
            zone.TextureID = int.Parse(txt_zone_textureID.Text);
            MessageBox.Show("Zone updated!");
            // Re-make tree node!
            tv_JSONStructure.Nodes.Add(ZoneToTree());
        }

        private void btn_npc_update_Click(object sender, EventArgs e)
        {
            // Update Properties
            npc.Name = txt_npc_name.Text;
            npc.Position = txt_npc_position.Text;
            npc.DefaultDialogue = txt_npc_dialogue.Text;
            npc.TextureId = int.Parse(txt_npc_textureID.Text);
            MessageBox.Show("NPC updated!");
            // Re-make tree node!
            tv_JSONStructure.Nodes.Add(ZoneToTree());
        }

        private void btn_obj_update_Click(object sender, EventArgs e)
        {
            obj.Name = txt_obj_name.Text;
            obj.Position = txt_obj_position.Text;
            obj.TextureId = int.Parse(txt_obj_textureID.Text);
            MessageBox.Show("Object updated!");
            // Re-make tree node!
            tv_JSONStructure.Nodes.Add(ZoneToTree());
        }

        private void btn_exit_update_Click(object sender, EventArgs e)
        {
            exit.Name = txt_exit_name.Name;
            exit.Position = txt_exit_position.Text;
            exit.ZoneId = int.Parse(txt_exit_zoneID.Text);
            exit.TextureId = int.Parse(txt_exit_textureID.Text);
            MessageBox.Show("Exit updated!");
            // Re-make tree node!
            tv_JSONStructure.Nodes.Add(ZoneToTree());
        }
    }
}
