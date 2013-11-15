<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="SigTrade.Models.BasePage"  UICulture="auto" Culture="auto" %>
<%@ Import Namespace="SigTrade.Models"%>
<%@ Import Namespace="SigTrade.Interfaces"%>
<%@ Import Namespace="System.Data"%>
<%@ Import Namespace="System.Threading"%>
<%@ Import Namespace="SignificantTrade.Models"%>

<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Import Namespace="System.Globalization"%>
<%@ Import Namespace="System.Resources"%>
<%@ Import Namespace="System.Web.Mvc"%>

<script runat="server" visible="False">

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ddKingdom.Items.Add("ALL");
            ddKingdom.DataSource = ViewData["Kingdom"];
            ddKingdom.DataValueField = "ID";
            ddKingdom.DataTextField = "Description";
            ddKingdom.DataBind();
            
            ddSpecies.DataSource = ViewData["Animals"];
            ddSpecies.DataValueField = "SpcRecID";
            ddSpecies.DataTextField = "SpcName";
            ddSpecies.DataBind();

            ddGenus.DataSource = ViewData["Animals"];
            ddGenus.DataValueField = "genrecid";
            ddGenus.DataTextField = "genname";
            ddGenus.DataBind();

            ddPhase.DataSource = ViewData["Phase"];
            ddPhase.DataValueField = "ID";
            ddPhase.DataTextField = "PhaseDesc";
            ddPhase.DataBind();
            
        }
        
        if (ViewState["CurrentData"] != null)
            showSelection();
        else
            hideSelection();
        //Need to put the Locale in this session variable
        Session["PreferredCulture"] = "en-US";
    }
    
    protected void hideSelection()
    {

       // this.btnSaveSpecies.Visible = false;
        this.lblSelectedSpecies.Visible = false;
    }
    
    protected void showSelection()
    {

       // this.btnSaveSpecies.Visible = true;
        this.lblSelectedSpecies.Visible = true;
        
    }

    protected override void InitializeCulture()
    {
        if (Session["PreferredCulture"] == null)
            Session["PreferredCulture"] = Request.UserLanguages[0];
        string UserCulture = Session["PreferredCulture"].ToString();
        if (UserCulture != "")
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(UserCulture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(UserCulture);
        }

        base.InitializeCulture();
    }
    
    
    protected void ddKingdom_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddKingdom.SelectedItem.Text.ToLower() == "animals".ToLower())
        {
            populateAnimals();
        }

        if (ddKingdom.SelectedItem.Text.ToLower() == "plants".ToLower())
        {
            populatePlants();
        }

    }
    
    private void populateAnimals()
    {

        ITaxonRepository taxon = new TaxonRepository();

      //  ddPhylum.Items.Add("ALL");
        ddPhylum.DataSource = taxon.getAPhylum();
        ddPhylum.DataValueField = "RecId";
        ddPhylum.DataTextField = "TaxonName";
        ddPhylum.DataBind();

      //  ddClass.Items.Add("ALL");
        ddClass.DataSource = taxon.getAClass();
        ddClass.DataValueField = "RecId";
        ddClass.DataTextField = "TaxonName";
        ddClass.DataBind();

      //  ddOrder.Items.Add("ALL");
        ddOrder.DataSource = taxon.getAOrder();
        ddOrder.DataValueField = "RecId";
        ddOrder.DataTextField = "TaxonName";
        ddOrder.DataBind();

      //  ddFamily.Items.Add("ALL");
        ddFamily.DataSource = taxon.getAFamily();
        ddFamily.DataValueField = "RecId";
        ddFamily.DataTextField = "TaxonName";
        ddFamily.DataBind();

       // ddGenus.Items.Add("ALL");
        ddGenus.DataSource = taxon.getAGenus();
        ddGenus.DataValueField = "RecId";
        ddGenus.DataTextField = "TaxonName";
        ddGenus.DataBind();

      //  ddSpecies.Items.Add("ALL");
        ddSpecies.DataSource = taxon.getASpecies();
        ddSpecies.DataValueField = "RecId";
        ddSpecies.DataTextField = "TaxonName";
        ddSpecies.DataBind();
    }
    
    private void populatePlants()
    {
        ITaxonRepository taxon = new TaxonRepository();

        ddPhylum.ClearSelection();
        ddPhylum.Enabled = false;

        ddClass.ClearSelection();
        ddClass.Enabled = false;

        ddOrder.ClearSelection();
        ddOrder.Enabled = false;

       // ddFamily.Items.Add("ALL");
        ddFamily.DataSource = taxon.getPFamily();
        ddFamily.DataValueField = "RecId";
        ddFamily.DataTextField = "TaxonName";
        ddFamily.DataBind();

     //   ddGenus.Items.Add("ALL");
        ddGenus.DataSource = taxon.getPGenus();
        ddGenus.DataValueField = "RecId";
        ddGenus.DataTextField = "TaxonName";
        ddGenus.DataBind();

      //  ddSpecies.Items.Add("ALL");
        ddSpecies.DataSource = taxon.getPSpecies();
        ddSpecies.DataValueField = "RecId";
        ddSpecies.DataTextField = "TaxonName";
        ddSpecies.DataBind();
        
    }

    protected void ddPhylum_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (ddKingdom.SelectedItem.Text.ToLower() == "animals".ToLower())
         {
             if (ddPhylum.SelectedItem.Text.ToLower() != "All".ToLower())
             {
                 int PhyRecId = int.Parse(ddPhylum.SelectedValue);
                 
                 
             }
         }

         if (ddKingdom.SelectedItem.Text.ToLower() == "plants".ToLower())
         {

         }

         clearRadioButtons();

    }

    protected void rbFamily_CheckedChanged(object sender, EventArgs e)
    {
       this.populateCountries(ddFamily, UpdateUtils.FAMILY);
      
    }
    
     protected void rbPhylum_CheckedChanged(object sender, EventArgs e)
    {
        this.populateCountries(ddPhylum, UpdateUtils.PHYLUM);
        
    }

    protected void rbClass_CheckedChanged(object sender, EventArgs e)
    {
        this.populateCountries(ddClass, UpdateUtils.CLASS);
       
    }

    protected void rbOrder_CheckedChanged(object sender, EventArgs e)
    {
        this.populateCountries(ddOrder, UpdateUtils.ORDER);
       
    }

    protected void rbGenus_CheckedChanged(object sender, EventArgs e)
    {
        this.populateCountries(ddGenus, UpdateUtils.GENUS);
      
        
    }

    protected void rbSpecies_CheckedChanged(object sender, EventArgs e)
    {
        this.populateCountries(ddSpecies, UpdateUtils.SPECIES);
        
    }
    
    protected void setSessionTaxon(string TaxonLevel, string TaxonName, int TaxonID)
    {

        Session["TaxonLevel"] = TaxonLevel;
        Session["TaxonName"] = TaxonName;
        Session["TaxonID"] = TaxonID;
    }
    
    protected string getSessionTaxonLevel()
    {
        return Session["TaxonLevel"].ToString();
    }

    protected string getSessionTaxonName()
    {
        return Session["TaxonName"].ToString();
    }

    protected string getSessionTaxonID()
    {
        return Session["TaxonID"].ToString();
    }
    
    
    protected void populateCountries(DropDownList obj, string TaxonName)
    {
        ITaxonRepository taxon = new TaxonRepository();

        setSessionTaxon(TaxonName, obj.SelectedItem.Text, int.Parse(obj.SelectedValue));
            
        if (ddKingdom.SelectedItem.Text.ToLower() == UpdateUtils.ANIMALS.ToLower())
        {
            int taxonId = int.Parse(obj.SelectedValue);
            ddCountry.DataSource = taxon.getCountries(taxonId, TaxonName, UpdateUtils.ANIMALS);
            ddCountry.DataValueField = "RecID";
            ddCountry.DataTextField = "TaxonName";
            ddCountry.DataBind();
        }

        if (ddKingdom.SelectedItem.Text.ToLower() == UpdateUtils.PLANTS.ToLower())
        {
            int taxonId = int.Parse(obj.SelectedValue);
            ddCountry.DataSource = taxon.getCountries(taxonId, TaxonName, UpdateUtils.PLANTS);
            ddCountry.DataValueField = "RecID";
            ddCountry.DataTextField = "TaxonName";
            ddCountry.DataBind();
        }
        
        
        
    }


    protected void ddSpecies_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearRadioButtons();
    }
    
    
    protected void clearRadioButtons()
    {

        rbPhylum.Checked = false;
        rbClass.Checked = false;
        rbOrder.Checked = false;
        rbFamily.Checked = false;
        rbGenus.Checked = false;
        rbSpecies.Checked = false;
        
    }

    
   
    private void BindGrid(int rowcount)
    {
        DataTable dt = new DataTable();
        DataRow dr;
       
        dt.Columns.Add(new System.Data.DataColumn("Phase", typeof(String)));
        dt.Columns.Add(new System.Data.DataColumn("PhaseID", typeof(String)));
        dt.Columns.Add(new System.Data.DataColumn("TaxonLevel", typeof(String)));
        dt.Columns.Add(new System.Data.DataColumn("TaxonName", typeof(String)));
        dt.Columns.Add(new System.Data.DataColumn("TaxonID", typeof(String)));
        dt.Columns.Add(new System.Data.DataColumn("Country", typeof(String)));
        dt.Columns.Add(new System.Data.DataColumn("CountryID", typeof(String)));
        dt.Columns.Add(new System.Data.DataColumn("Kingdom", typeof(String)));

        if (ViewState["CurrentData"] != null)
        {
            for (int i = 0; i < rowcount + 1; i++)
            {
                dt = (DataTable)ViewState["CurrentData"];
                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = dt.Rows[0][0].ToString();

                }
            }
            dr = dt.NewRow();
            dr[0] = ddPhase.SelectedItem.Text;
            dr[1] = ddPhase.SelectedValue;
            dr[2] = getSessionTaxonLevel();
            dr[3] = this.getSessionTaxonName();
            dr[4] = this.getSessionTaxonID();
            dr[5] = ddCountry.SelectedItem.Text;
            dr[6] = ddCountry.SelectedValue;
            dr[7] = ddKingdom.SelectedItem.Text;
            dt.Rows.Add(dr);

        }
        else
        {
            dr = dt.NewRow();
            dr[0] = ddPhase.SelectedItem.Text;
            dr[1] = ddPhase.SelectedValue;
            dr[2] = getSessionTaxonLevel();
            dr[3] = this.getSessionTaxonName();
            dr[4] = this.getSessionTaxonID();
            dr[5] = ddCountry.SelectedItem.Text;
            dr[6] = ddCountry.SelectedValue;
            dr[7] = ddKingdom.SelectedItem.Text;
            
            dt.Rows.Add(dr);

        }

        // If ViewState has a data then use the value as the DataSource
        if (ViewState["CurrentData"] != null)
        {
            gvSelectedSpecies.DataSource = (DataTable)ViewState["CurrentData"];
            this.gvSelectedSpecies.DataBind();
        }
        else
        {
            // Bind GridView with the initial data assocaited in the DataTable
            gvSelectedSpecies.DataSource = dt;
            gvSelectedSpecies.DataBind();

        }
        // Store the DataTable in ViewState to retain the values
        ViewState["CurrentData"] = dt;
        TempData["CurrentData"] = ViewState["CurrentData"];

    }


    protected void btnSelected_Click(object sender, EventArgs e)
    {
        // Check if the ViewState has a data assoiciated within it. If
        if (ViewState["CurrentData"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentData"];
            int count = dt.Rows.Count;
            BindGrid(count);
        }
        else
        {
            BindGrid(1);
        }

    }

    protected void btnSelected_Click1(object sender, EventArgs e)
    {
        // Check if the ViewState has a data assoiciated within it. If
        if (ViewState["CurrentData"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentData"];
            int count = dt.Rows.Count;
            BindGrid(count);
        }
        else
        {
            BindGrid(1);
        }

    }
    
    protected void saveSelectedSpecies()
    {


        if (ViewState["CurrentData"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentData"];
             int rowcount = dt.Rows.Count;
            ITaxonRepository taxon = new TaxonRepository();
            for (int i = 0; i < rowcount; i++)
            {
                DataRow dr = dt.Rows[i];
                
                    Review r = new Review();
            //    dr[0] = ddPhase.SelectedItem.Text;
            //dr[1] = ddPhase.SelectedValue;
            //dr[2] = getSessionTaxonLevel();
            //dr[3] = this.getSessionTaxonName();
            //dr[4] = this.getSessionTaxonID();
            //dr[5] = ddCountry.SelectedItem.Text;
            //dr[6] = ddCountry.SelectedValue;
                
                r.PhaseID = int.Parse(dr[1].ToString());
                r.KingdomID = taxon.getTaxonLevelID(dr[7].ToString());
                r.TaxonLevel = taxon.getTaxonLevelID(dr[2].ToString());
                r.TaxonID = int.Parse(dr[4].ToString());
                r.DateAdded = DateTime.Now;
                r.CountryID = int.Parse(dr[6].ToString());

                taxon.SaveReview(r);

                }
            }
        
    }


    protected void ddGenus_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearRadioButtons();
    }

    protected void ddFamily_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearRadioButtons();
    }

    protected void ddOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearRadioButtons();
    }

    protected void ddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearRadioButtons();
    }

    //protected void btnSaveSpecies_Click(object sender, EventArgs e)
    //{
    //    this.saveSelectedSpecies();
    //    gvSelectedSpecies.DataSource = null;
    //    ViewState["CurrentData"] = null;
    //    gvSelectedSpecies.DataBind();
    //    new RedirectToRouteResult(new RouteValueDictionary(new {controller = "AddReview", action = "List"}));
    //}

    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><asp:Literal id="Literal3" Text="<%$Resources:SigTrade, lblReviewIndexTitle%>" runat="server"/></title>
    <style type="text/css">
        #Button1
        {
            width: 82px;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   
    <form id="form1" runat="server">
    <h2 align="left">
        <asp:Label ID="lblReviewIndexTitle" runat="server" Text="<%$Resources:SigTrade, lblReviewIndexTitle%>"></asp:Label>
    </h2>
    
    <h3>
    1. <asp:Label ID="lblAddPhaseTitle" runat="server" Text="<%$Resources:SigTrade, lblAddPhaseTitle%>"></asp:Label>
    </h3>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
   <table>
   <tr>
   <td>
        <asp:UpdatePanel ID="upSpeciesSelection" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table>
        
          <tr>
          
        
            <td>
                       <asp:Label ID="lblAddPhase" runat="server" 
                    Text="<%$ Resources:SigTrade, lblAddPhase %>"></asp:Label>
            </td>
        <td>
        <asp:DropDownList ID="ddPhase" runat="server" AutoPostBack="true"           
                AppendDataBoundItems="True">
            </asp:DropDownList>
            
            
        </td>
        </tr>
        
        </table>
        
        <h3>
        2. &nbsp;<asp:Label ID="lblAddSpeciesTitle" runat="server" Text="<%$Resources:SigTrade, lblAddSpeciesTitle%>"></asp:Label>
            </h3>       
        
       
        <table>
        <tr>   
        
        <td>
            <asp:Label ID="lblKingdom" runat="server" Text="<%$Resources:SigTrade, lblKingdom.Text%>"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="ddKingdom" runat="server" AutoPostBack="true"
                onselectedindexchanged="ddKingdom_SelectedIndexChanged" 
                AppendDataBoundItems="True">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
        
            <td>
            <asp:Label ID="lblPhylum" runat="server" Text="<%$Resources:SigTrade, lblPhylum%>"></asp:Label>
            </td> 
            
        <td>
            <asp:DropDownList ID="ddPhylum" runat="server" AppendDataBoundItems="True" 
                onselectedindexchanged="ddPhylum_SelectedIndexChanged" >
            </asp:DropDownList>
            </td>
            <td>
             <asp:RadioButton ID="rbPhylum" runat="server" GroupName="SpeciesSelect" 
                 AutoPostBack="True" oncheckedchanged="rbPhylum_CheckedChanged" />
            </td> 
        </tr>
        <tr>
         
        <td>
            <asp:Label ID="lblClass" runat="server" Text="<%$Resources:SigTrade, lblClass%>"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="ddClass" runat="server" AppendDataBoundItems="True" 
                AutoPostBack="True" onselectedindexchanged="ddClass_SelectedIndexChanged" >
            </asp:DropDownList>
            </td>
            <td>
             <asp:RadioButton ID="rbClass" runat="server" GroupName="SpeciesSelect" 
                 AutoPostBack="True" oncheckedchanged="rbClass_CheckedChanged" />
            </td> 
        </tr>
        <tr>
         
       
        <td>
            <asp:Label ID="lblOrder" runat="server" Text="<%$Resources:SigTrade, lblOrder%>"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="ddOrder" runat="server" AppendDataBoundItems="True" 
                AutoPostBack="True" onselectedindexchanged="ddOrder_SelectedIndexChanged" >
            </asp:DropDownList>
            </td>
            <td>
             <asp:RadioButton ID="rbOrder" runat="server" GroupName="SpeciesSelect" 
                 oncheckedchanged="rbOrder_CheckedChanged" />
            </td> 
        </tr>
        <tr>
          
         
        <td><asp:Label ID="lblFamily" runat="server" Text="<%$Resources:SigTrade, lblFamily%>"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="ddFamily" runat="server" AutoPostBack="True" 
                AppendDataBoundItems="True" 
                onselectedindexchanged="ddFamily_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
            <td>
             <asp:RadioButton ID="rbFamily" runat="server" GroupName="SpeciesSelect" 
                 oncheckedchanged="rbFamily_CheckedChanged" AutoPostBack="True" />
            </td>
        </tr>
        <tr>
         
        
        <td>
            <asp:Label ID="lblGenus" runat="server" Text="<%$Resources:SigTrade, lblGenus%>"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="ddGenus" runat="server" AutoPostBack="True" 
                AppendDataBoundItems="True">
            </asp:DropDownList>
            </td>
            <td>
             <asp:RadioButton ID="rbGenus" runat="server" GroupName="SpeciesSelect" 
                 AutoPostBack="True" oncheckedchanged="rbGenus_CheckedChanged" />
            </td> 
        </tr>
        <tr>
        
      
        <td><asp:Label ID="lblSpecies" runat="server" Text="<%$Resources:SigTrade, lblSpecies%>"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="ddSpecies" runat="server" AppendDataBoundItems="True" 
                onselectedindexchanged="ddSpecies_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
            </td>
             <td>
             <asp:RadioButton ID="rbSpecies" runat="server" GroupName="SpeciesSelect" 
                 AutoPostBack="True" oncheckedchanged="rbSpecies_CheckedChanged" />
            </td> 
        </tr>   
        
        </table>
        
        <h3>
        3. <asp:Label ID="lblAddCountryTitle" runat="server" Text="<%$Resources:SigTrade, lblAddCountryTitle%>"></asp:Label>
        </h3>
        <table>
        <tr>
        <td>
        
            <asp:Label ID="lblAddCountry" runat="server" Text="<%$Resources:SigTrade, lblAddCountry%>"></asp:Label>
        
        </td>
        <td>
        
            <asp:DropDownList ID="ddCountry" runat="server">
            </asp:DropDownList>     
           
        
        </td>
        
        </tr>
        <tr>
        <td>
       <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                AssociatedUpdatePanelID="upSpeciesSelection">
                <ProgressTemplate>
                                    LOADING... </ProgressTemplate>
            </asp:UpdateProgress>
            </td>
        </tr>
        </table>
        </ContentTemplate>
            
        </asp:UpdatePanel>
        <tr>
         <td><asp:Button ID="btnSelected" runat="server" 
                Text="<%$Resources:SigTrade, btnSelected%>" onclick="btnSelected_Click" />
            </td>
        </tr>
    </td>
   <td>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
   <table>
    <tr>
    <td>
    
        <asp:Label ID="lblSelectedSpecies" runat="server" Text="<%$Resources:SigTrade, lblSelectedSpecies%>" ></asp:Label>
    </td>
    </tr>
    <tr>
    <td>    
        <asp:GridView ID="gvSelectedSpecies" runat="server" AllowSorting="True" >
        </asp:GridView>        
    </td>
    
    </tr>
  <tr>
  
   <%--<td>
      <asp:Button ID="btnSaveSpecies" runat="server" Text="<%$Resources:SigTrade, btnSaveSpecies%>" onclick="btnSaveSpecies_Click" />
      </td>--%>
      <td>     
      <%=Html.ActionLink("Save Selection","List","AddReview")%>
      </td>
   </tr>
        
    </table>

    </ContentTemplate>       
    </asp:UpdatePanel>
    </td>
   </tr>
    
     
    </table>

    </form>

</asp:Content>

