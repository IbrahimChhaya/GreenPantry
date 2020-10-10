<%@ Page Language="C#" MasterPageFile="~/dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="GreenPantryFrontend.dashboard.edituser" %>

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
                  <h3 class="mb-0" id="editName" runat="server">Edit User #1</h3>
                </div>
                <div class="col-4 text-right">
                    <label id="error" runat="server" visible="false">Error</label>
                    <a href="#!" class="btn btn-sm btn-primary" id="updateUser" runat="server" onserverclick="updateUser_ServerClick">Update</a>
                    <a href="#!" class="btn btn-sm btn-primary" id="addUser" runat="server" onserverclick="addUser_ServerClick" visible="false">Add</a>
                </div>
              </div>
            </div>
            <div class="card-body">
              <form runat="server">
                <h6 class="heading-small text-muted mb-4" id="Details" runat="server">User Details</h6>
                <div class="pl-lg-4">
                  <div class="row">
                    <div class="col-lg-6">
                      <div class="form-group">
                        <label class="form-control-label" for="input-first-name">Email</label>
                        <input type="text" id="email" class="form-control" runat="server" disabled>
                      </div>
                    </div>
                      <div class="col-lg-6">
                          <div class="form-group">
                            <label class="form-control-label" for="input-first-name">Points</label>
                            <input type="number" id="points" class="form-control" runat="server" required>
                          </div>
                      </div>
                  </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group" id="CategoryStatus" runat="server">
                                <label for="dropdownStatus" class="form-control-label">Status</label>
                            
                                <asp:DropDownList ID="dropdownStatus" runat="server" CssClass="form-control" >
                                </asp:DropDownList>  
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group" id="typeList" runat="server">
                                <label for="dropdownType" class="form-control-label">User Type</label>
                            
                                <asp:DropDownList ID="dropdownType" runat="server" class="form-control">
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
