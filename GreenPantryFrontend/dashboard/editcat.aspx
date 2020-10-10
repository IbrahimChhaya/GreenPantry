<%@ Page Language="C#" MasterPageFile="~/dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="editcat.aspx.cs" Inherits="GreenPantryFrontend.dashboard.editcat" %>

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
                <h4 class="text-white">Howdy, Ibrahim!</h4>
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
                  <h3 class="mb-0" id="editName" runat="server">Edit bakery, bread and shit</h3>
                </div>
                <div class="col-4 text-right">
                    <label id="error" runat="server" visible="false">Error</label>
                    <a href="#!" class="btn btn-sm btn-primary" id="updateCat" runat="server" onserverclick="updateCat_ServerClick">Update</a>
                    <a href="#!" class="btn btn-sm btn-primary" id="addCat" runat="server" onserverclick="addCat_ServerClick" visible="false">Add</a>
                </div>
              </div>
            </div>
            <div class="card-body">
              <form runat="server">
                <h6 class="heading-small text-muted mb-4" id="Details" runat="server">Category Details</h6>
                <div class="pl-lg-4">
                  <div class="row">
                    <div class="col-lg-6">
                      <div class="form-group">
                        <label class="form-control-label" for="input-first-name">Name</label>
                        <input type="text" id="name" class="form-control" runat="server" required>
                      </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group" id="CategoryStatus" runat="server">
                            <label for="dropdownStatus" class="form-control-label">Status</label>
                            
                            <asp:DropDownList ID="dropdownStatus" runat="server" CssClass="form-control" >
                            </asp:DropDownList>  
                        </div>
                    </div>
                  </div>
                    <div class="row" id="catDropdown" runat="server" visible="false">
                    <div class="col-lg-6">
                        <div class="form-group" id="catList" runat="server">
                            <label for="dropdownCat" class="form-control-label">Category</label>
                            
                            <asp:DropDownList ID="dropdownCat" runat="server" class="form-control">
                            </asp:DropDownList> 
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