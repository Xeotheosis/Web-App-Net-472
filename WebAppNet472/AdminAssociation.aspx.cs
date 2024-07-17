using BussinesLogic.Services;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppNet472
{
    public partial class AdminAssociation : System.Web.UI.Page
    {
        private readonly UserService _userService;
        private readonly AssociationService _associationService;
        private readonly BuildingService _buildingService;
        private readonly StaircaseService _staircaseService;
        private readonly ApartmentService _apartmentService;

        public AdminAssociation()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
            var userRepository = new UserRepository();
            var associationRepository = new AssociationRepository();
            var buildingRepository = new BuildingRepository();
            var staircaseRepository = new StaircaseRepository();
            var apartmentRepository = new ApartmentRepository();
            _userService = new UserService(userRepository);
            _associationService = new AssociationService(associationRepository);
            _buildingService = new BuildingService(buildingRepository);
            _staircaseService = new StaircaseService(staircaseRepository);
            _apartmentService = new ApartmentService(apartmentRepository);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadAssociations();
            }
        }

        private async void LoadAssociations()
        {
            var userId = await _userService.GetUserIdByUsernameAsync(User.Identity.Name);
            var associations = _userService.GetUserAssociations(userId).ToList();
            ddlAssociations.DataSource = associations;
            ddlAssociations.DataTextField = "Name";
            ddlAssociations.DataValueField = "AssociationId";
           
            ddlAssociations.DataBind();
            ddlAssociations.Items.Insert(0, "--Selectati o asociatie--");
        }

        protected void ddlAssociations_SelectedIndexChanged(object sender, EventArgs e)
        {
            divBuildings.Visible = true;
            LoadBuildings();
        }

        protected async void btnAddBuilding_Click(object sender, EventArgs e)
        {
            var name = txtBuildingName.Text;
            var associationId = int.Parse(ddlAssociations.SelectedValue);

            try
            {
                await _buildingService.AddBuildingAsync(associationId, name);
                lblBuildingMessage.Text = "Building added successfully.";
                ClearBuildingForm();
                LoadBuildings();
            }
            catch (Exception ex)
            {
                lblBuildingMessage.Text = "Error adding building: " + ex.Message;
            }
        }

        protected void gvBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            divStaircases.Visible = true;
            LoadStaircases();
        }

        protected async void btnAddStaircase_Click(object sender, EventArgs e)
        {
            var buildingId = (int)gvBuildings.SelectedDataKey.Value;
            var name = txtStaircaseName.Text;

            try
            {
                await _staircaseService.AddStaircaseAsync(buildingId, name);
                lblStaircaseMessage.Text = "Staircase added successfully.";
                ClearStaircaseForm();
                LoadStaircases();
            }
            catch (Exception ex)
            {
                lblStaircaseMessage.Text = "Error adding staircase: " + ex.Message;
            }
        }

        protected void gvStaircases_SelectedIndexChanged(object sender, EventArgs e)
        {
            divApartments.Visible = true;
            LoadApartments();
        }

        protected async void btnAddApartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApartmentForm.aspx?staircaseId=" + gvStaircases.SelectedDataKey.Value, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private async void LoadBuildings()
        {
            var associationId = int.Parse(ddlAssociations.SelectedValue);
            var buildings = await _buildingService.GetBuildingsByAssociationIdAsync(associationId);
            gvBuildings.DataSource = buildings;
            gvBuildings.DataBind();
        }

        private async void LoadStaircases()
        {
            var buildingId = (int)gvBuildings.SelectedDataKey.Value;
            var staircases = await _staircaseService.GetStaircasesByBuildingIdAsync(buildingId);
            gvStaircases.DataSource = staircases;
            gvStaircases.DataBind();
        }
      
        private async void LoadApartments()
        {
            var staircaseId = (int)gvStaircases.SelectedDataKey.Value;
            var apartments = await _apartmentService.GetApartmentsByStaircaseIdAsync(staircaseId);
            gvApartments.DataSource = apartments;
            gvApartments.DataBind();
        }

        private void ClearBuildingForm()
        {
            txtBuildingName.Text = string.Empty;
        }

        private void ClearStaircaseForm()
        {
            txtStaircaseName.Text = string.Empty;
        }

        protected void gvApartments_RowEditing(object sender, GridViewEditEventArgs e)
        {
             
                var apartmentId = (int)gvApartments.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("ApartmentForm.aspx?apartmentId=" + apartmentId, false);
                Context.ApplicationInstance.CompleteRequest();
            
        }
    }
}