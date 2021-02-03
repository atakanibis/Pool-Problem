using FordFulkersonConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab23
{
    public partial class Form1 : Form
    {
        int _counter = 1;
        Dictionary<int, string> Nodes = new Dictionary<int, string>();
        List<Edge> Edges = new List<Edge>();
        int _start, _end = 0;
        public class Edge
        {
            public int nodeFrom { get; set; }
            public int nodeTo { get; set; }
            public int capacity { get; set; }
            public override string ToString()
            {
                return String.Format("{0} {1} {2}", nodeFrom, nodeTo, capacity);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ListViewItem row = new ListViewItem(_counter.ToString());
            row.SubItems.Add(textBox1.Text);
            listView1.Items.Add(row);
            Nodes.Add(_counter, textBox1.Text);
            comboBox1.Items.Add(textBox1.Text);
            comboBox2.Items.Add(textBox1.Text);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
            textBox1.Text = "";
            _counter++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem row = new ListViewItem(textBox2.Text);
            row.SubItems.Add(textBox3.Text);
            row.SubItems.Add(textBox4.Text);
            listView2.Items.Add(row);
            var nodeFromId = Nodes.FirstOrDefault(x => x.Value == textBox2.Text).Key;
            var nodeToId = Nodes.FirstOrDefault(x => x.Value == textBox3.Text).Key;
            Edges.Add(new Edge() { nodeFrom = nodeFromId, nodeTo = nodeToId, capacity = Int32.Parse(textBox4.Text)});
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string names = string.Join(" ", Nodes.Values.ToArray());
            string[] edges = new string[Edges.Count];
            int i = 0;
            foreach(var edge in Edges)
            {
                edges[i++] = edge.ToString();
            }
            var solver = new ProblemSolver(names, edges, _start, _end);
            solver.Run();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _start = comboBox1.SelectedIndex + 1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _end = comboBox2.SelectedIndex + 1;
        }

    }
}
