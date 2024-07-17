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
    public partial class ApartmentForm : System.Web.UI.Page
    {
        private readonly ApartmentService _apartmentService;

        public ApartmentForm()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["AsPropManagerDb"].ConnectionString;
            var apartmentRepository = new ApartmentRepository();
            _apartmentService = new ApartmentService(apartmentRepository);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load apartment data if editing
                if (Request.QueryString["apartmentId"] != null)
                {
                    LoadApartmentData(int.Parse(Request.QueryString["apartmentId"]));
                }
            }
        }

        protected async void btnSaveApartment_Click(object sender, EventArgs e)
        {
            int staircaseId;
            if (Request.QueryString["apartmentId"] == null)
            {
                staircaseId = int.Parse(Request.QueryString["staircaseId"]);
            }
            else
            {
                var apartment = await _apartmentService.GetApartmentByIdAsync(int.Parse(Request.QueryString["apartmentId"]));
                staircaseId = apartment.StaircaseId;
            }

            var hasGasCentralHeating = chkHasGasCentralHeating.Checked;
            var surfaceArea = float.Parse(txtSurfaceArea.Text);
            var peopleCount = int.Parse(txtPeopleCount.Text);
            var coldWaterMeterReading = string.IsNullOrEmpty(txtColdWaterMeterReading.Text) ? (float?)null : float.Parse(txtColdWaterMeterReading.Text);
            var hotWaterMeterReading = string.IsNullOrEmpty(txtHotWaterMeterReading.Text) ? (float?)null : float.Parse(txtHotWaterMeterReading.Text);

            try
            {
                if (Request.QueryString["apartmentId"] == null)
                {
                    await _apartmentService.AddApartmentAsync(staircaseId, hasGasCentralHeating, surfaceArea, peopleCount, coldWaterMeterReading, hotWaterMeterReading);
                    lblApartmentMessage.Text = "Apartment added successfully.";
                }
                else
                {
                    var apartmentId = int.Parse(Request.QueryString["apartmentId"]);
                    var number = txtApartmentNumber.Text;
                    await _apartmentService.UpdateApartmentAsync(apartmentId, staircaseId, number, hasGasCentralHeating, surfaceArea, peopleCount, coldWaterMeterReading, hotWaterMeterReading);
                    lblApartmentMessage.Text = "Apartment updated successfully.";
                }
                ClearForm();
            }
            catch (Exception ex)
            {
                lblApartmentMessage.Text = "Error saving apartment: " + ex.Message;
            }
        }

        private async void LoadApartmentData(int apartmentId)
        {
            var apartment = await _apartmentService.GetApartmentByIdAsync(apartmentId);
            txtApartmentNumber.Text = apartment.Number;
            chkHasGasCentralHeating.Checked = apartment.HasGasCentralHeating;
            txtSurfaceArea.Text = apartment.SurfaceArea.ToString();
            txtPeopleCount.Text = apartment.PeopleCount.ToString();
            txtColdWaterMeterReading.Text = apartment.ColdWaterMeterReading.ToString();
            txtHotWaterMeterReading.Text = apartment.HotWaterMeterReading?.ToString();
        }

        private void ClearForm()
        {
            txtApartmentNumber.Text = string.Empty;
            chkHasGasCentralHeating.Checked = false;
            txtSurfaceArea.Text = string.Empty;
            txtPeopleCount.Text = string.Empty;
            txtColdWaterMeterReading.Text = string.Empty;
            txtHotWaterMeterReading.Text = string.Empty;
        }
    }

}