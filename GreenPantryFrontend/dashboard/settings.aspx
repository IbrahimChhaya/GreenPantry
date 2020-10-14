<%@ Page Language="C#" MasterPageFile="~/dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="GreenPantryFrontend.dashboard.settings" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!-- Main content -->
  <div class="main-content" id="panel">
    
    <!-- Header -->
    <div class="header bg-primary pb-6">
      <div class="container-fluid">
        <div class="header-body">
          <div class="row align-items-center py-4">
            <div class="col-lg-6 col-7">
              <h6 class="h2 text-white d-inline-block mb-0"></h6>
            </div>
            <div class="col-lg-6 col-5 text-right">
                <h4 class="text-white" id="howdy" runat="server">Howdy, Ibrahim!</h4>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid mt--6">
      <div class="row">
        <div class="col-xl-8 order-xl-1">
          <div class="card">
            <div class="card-header">
              <div class="row align-items-center">
                <div class="col-8">
                  <h3 class="mb-0">Edit Site Settings</h3>
                </div>
                <div class="col-4 text-right">
                    <label id="error" runat="server" visible="false">Error</label>
                    <a href="#!" class="btn btn-sm btn-primary" id="updateSite" runat="server" onserverclick="updateSite_ServerClick">Update</a>
                </div>
              </div>
            </div>
            <div class="card-body">
              <form runat="server">
                <h6 class="heading-small text-muted mb-4">Settings</h6>
                <div class="pl-lg-4">
                  <div class="row">
                    <div class="col-lg-6">
                      <div class="form-group">
                        <label class="form-control-label" for="name">Site Name</label>
                        <input type="text" id="name" class="form-control" runat="server" required>
                      </div>
                    </div>
                      <div class="col-lg-6">
                          <div class="form-group">
                            <label class="form-control-label" for="minimum">Minimum for Free Shipping</label>
                            <input type="number" id="minimum" class="form-control" runat="server" value="500" required>
                          </div>
                      </div>
                  </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="form-control-label" for="minimum">VAT</label>
                                <input type="number" id="vat" class="form-control" runat="server" value="15" required>
                            </div>
                        </div>
                    </div>
                    <h6 class="heading-small text-muted mb-4">Home Page Promotions</h6>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <!-- 0 for banners, 1 for first banner-->
                                <!-- 1 for big banners-->
                                <a href="edithome.aspx?action=0&ID=2" class="btn btn-sm btn-outline-primary">Banner 1</a>
                                <a href="edithome.aspx?action=0&ID=3" class="btn btn-sm btn-outline-primary">Banner 2</a>
                                <a href="edithome.aspx?action=0&ID=4" class="btn btn-sm btn-outline-primary">Banner 3</a>
                                <a href="edithome.aspx?action=0&ID=5" class="btn btn-sm btn-outline-primary">Banner 4</a>
                            </div>
                        </div>
                    </div>
                    <h6 class="heading-small text-muted mb-4">Home Page Long Banners</h6>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <!-- 0 for banners, 1 for first banner-->
                                <!-- 1 for big banners-->
                                <a href="edithome.aspx?action=1&ID=6" class="btn btn-sm btn-outline-primary">Long Banner 1</a>
                                <a href="edithome.aspx?action=1&ID=7" class="btn btn-sm btn-outline-primary">Long Banner 1</a>
                            </div>
                        </div>
                    </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
</div>
    </asp:Content>
