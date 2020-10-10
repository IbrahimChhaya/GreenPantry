<%@ Page Language="C#" MasterPageFile="~/dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="editorder.aspx.cs" Inherits="GreenPantryFrontend.dashboard.editorder" %>

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
                  <h3 class="mb-0" id="editName" runat="server">Edit Order</h3>
                </div>
                <div class="col-4 text-right">
                    <label id="error" runat="server" visible="false">Error</label>
                    <a href="#!" class="btn btn-sm btn-primary" id="updateOrder" runat="server" onserverclick="updateOrder_ServerClick">Update</a>
                </div>
              </div>
            </div>
            <div class="card-body">
              <form runat="server">
                <h6 class="heading-small text-muted mb-4">Order Details</h6>
                <div class="pl-lg-4">
                  <div class="row">
                    
                    <!-- Light table -->
                    <div class="table-responsive">
                      <table class="table align-items-center table-flush">
                        <thead class="thead-light">
                          <tr>
                            <th scope="col" class="sort" data-sort="name">Product</th>
                            <th scope="col" class="sort" data-sort="budget">Price</th>
                            <th scope="col" class="sort" data-sort="budget">Quantity</th>
                            <%--<th scope="col" class="sort" data-sort="status">Status</th>
                            <th scope="col"></th>
                            <th scope="col"></th>--%>
                          </tr>
                        </thead>
                        <tbody class="list" id="productList" runat="server">
                          <tr>
                            <th scope="row">
                              <div class="media align-items-center">
                                <div class="media-body">
                                  <span class="name mb-0 text-sm">Bamboo Towels</span>
                                </div>
                              </div>
                            </th>
                            <td class="budget">
                              R2500 
                            </td>
                              <td class="budget">
                                  1
                              </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                </div>
                    <br />
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="form-control-label" for="input-last-name" id="userID" runat="server">User</label>
                            <input type="text" id="email" class="form-control" runat="server" disabled>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="form-control-label" for="input-last-name">Date Placed</label>
                            <input type="text" id="datePlaced" class="form-control" runat="server" disabled>
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
                        <div class="form-group">
                                <label class="form-control-label">Notes</label>
                                <textarea rows="4" class="form-control" id="notes" runat="server" required></textarea>
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