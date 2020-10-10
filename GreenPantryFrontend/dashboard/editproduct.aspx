<%@ Page Language="C#" MasterPageFile="~/dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="editproduct.aspx.cs" Inherits="GreenPantryFrontend.dashboard.editproduct" %>

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
                  <h3 class="mb-0" id="editName" runat="server">Edit bread</h3>
                </div>
                <div class="col-4 text-right">
                    <a href="#!" class="btn btn-sm btn-primary" id="updateProduct" runat="server" onserverclick="updateProduct_ServerClick">Update</a>
                    <a href="#!" class="btn btn-sm btn-primary" id="addProduct" runat="server" onserverclick="addProduct_ServerClick" visible="false">Add</a>
                </div>
              </div>
            </div>
            <div class="card-body">
              <form runat="server">
                <h6 class="heading-small text-muted mb-4">Product Details</h6>
                <div class="pl-lg-4">
                 <div class="row justify-content-center" id="imgPath" runat="server">
                    <img src="../img/Products/0.png" alt="Image placeholder" class="card-img-top">
                 </div>
                    <div class="row justify-content-center">
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                          <div class="d-flex justify-content-between">
                              
                            <!-- Button trigger modal -->
                            <button type="button" class="btn btn-sm btn-primary" data-toggle="modal" data-target="#exampleModal">
                                Upload New Image
                            </button>
                            <!-- Modal -->
                            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel">Upload New Product Image</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <asp:FileUpload id="FileUpLoad1" runat="server" accept="image/*"/>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary" id="uploadbtn" runat="server" onserverclick="upload_ServerClick" data-dismiss="modal">Upload New Image</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          </div>
                              <label id="error" runat="server" visible="false">bruh</label>
                        </div>
                    </div>
                  <div class="row">
                    <div class="col-lg-6">
                      <div class="form-group">
                        <label class="form-control-label" for="input-first-name">Name</label>
                        <input type="text" id="name" class="form-control" runat="server" required>
                      </div>
                    </div>
                    <div class="col-lg-6">
                      <div class="form-group">
                        <label class="form-control-label" for="input-last-name">Stock</label>
                        <input type="number" id="stock" min=0 class="form-control" runat="server" required>
                      </div>
                    </div>
                  </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="form-control-label" for="input-last-name">Cost</label>
                            <input type="number" id="cost" min="0" class="form-control" runat="server" required>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="form-control-label" for="input-last-name">Price</label>
                            <input type="number" id="price" min="0" class="form-control" runat="server" required>
                        </div>
                    </div>
                </div>
                  <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group" id="subcatList" runat="server">
                            <label for="dropdownSub" class="form-control-label">SubCategory</label>
                            
                            <asp:DropDownList ID="dropdownSub" runat="server" class="form-control">
                            </asp:DropDownList> 
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group" id="statusDropdown" runat="server">
                            <label for="dropdownStatus" class="form-control-label">Status</label>
                            
                            <asp:DropDownList ID="dropdownStatus" runat="server" CssClass="form-control" >
                            </asp:DropDownList>    

                        </div>
                    </div>
                  </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="form-control-label">Description</label>
                                <textarea rows="4" class="form-control" id="description" runat="server" required></textarea>
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