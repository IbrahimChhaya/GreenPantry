<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="addressbook.aspx.cs" Inherits="GreenPantryFrontend.addressbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="breadcrumb__text">
                        <h2>Address Book</h2>
                        <div class="breadcrumb__option">
                            <a href="./home.aspx">Home</a>
                            <span>Address Book</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    <section class="checkout spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12"></div>
            </div>
            <div class="checkout__form">
                <h4>
                    Delivery Address
                    <a href="addressbook.aspx?ID=0" class="site-btn" style="float: right; margin-right: 390px;" id="addNew" runat="server">Add New Address</a>
                </h4>
<%--                <form action="#" runat="server">--%>
                    <div class="row">

                        <div class="col-lg-8 col-md-6" runat="server" id="newAddress" visible="false">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="checkout__input">
                                    </div>
                                </div>
                            </div>
                            <asp:Label ID="error" Font-Size="14px" Text="An error has occurred" runat="server" Visible="false" />
                            <div class="checkout__input">
                                <input type="text" id="aID" runat="server" style="display:none;" />
                                <input type="text" id="pr" runat="server" style="display:none;" />
                                <p>Give This Address A Name</p>
                                <input type="text" placeholder="Home/Business" id="type" runat="server" required>
                            </div>
                            <div class="checkout__input">
                                <p>Address</p>
                                <input type="text" placeholder="Street Address" class="checkout__input__add" id="line1" runat="server" required>
                                <input type="text" placeholder="Apartment, suite, unit, ect (optional)" id="line2" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Suburb</p>
                                <input type="text" placeholder="Suburb" id="suburb" runat="server" required>
                            </div>
                            <div class="checkout__input">
                                <p>Town/City</p>
                                <input type="text" placeholder="Town or City" id="town" runat="server" required>
                            </div>
                            <div class="checkout_input">
                                <p style="color: #1c1c1c;margin-bottom: 20px;">Province</p>
                                <select name="province" id="provincesList" runat="server">
                                    <option value="Province" disabled selected hidden>Province</option>
                                    <option value="Eastern Cape">Eastern Cape</option>
                                    <option value="Free State">Free State</option>
                                    <option value="Gauteng">Gauteng</option>
                                    <option value="KwaZulu-Natal">KwaZulu-Natal</option>
                                    <option value="Limpopo">Limpopo</option>
                                    <option value="Mpumalanga">Mpumalanga</option>
                                    <option value="Northern Cape">Northern Cape</option>
                                    <option value="North West">North West</option>
                                    <option value="Western Cape">Western Cape</option>
                                </select>
                            </div>

                            <br />
                            <br />
                            <br />
                            
                            <div class="checkout__input">
                                <p>Postcode / ZIP</p>
                                <input type="number" Placeholder="Postal Code" id="postcode" runat="server" required>
                            </div>
                            <div class="checkout__input">
                                <p>Phone Number</p>
                                <input type="number" Placeholder="Phone number" id="number" runat="server" required>
                            </div>
                            <asp:Button ID="updateBtn" Text="Update Address" runat="server" class="site-btn"  OnCLick="updateBtn_Click" Visible="false" />
                            <asp:Button ID="Submit" Text="Save Address" runat="server" class="site-btn"  OnCLick="Submit_Click" Visible="false"/>
                        </div>



                        <div class="col-lg-8 col-md-6" runat="server" id="oldAddress" visible="false">
                            <div class="checkout__order">
                                <div>
                                    <label><b>Home</b></label>
                                </div>
                                <div>
                                    <label>1 Smith road</label>
                                </div>
                                <div>
                                    <label>Bedfordview, Johannesburg, 2007</label>
                                    <label class="gpLabel2" style="float:right;">Delete</label>
                                    <label class="gpLabel2" style="float:right;">Edit</label> 
                                </div>
                            </div>

                            <br />

                            <div class="checkout__order">
                                <div>
                                    <label><b>Business</b></label>
                                </div>
                                <div>
                                    <label>1 Smith road</label>
                                </div>
                                <div>
                                    <label>Bedfordview, Johannesburg, 2007</label>
                                    <label class="gpLabel2" style="float:right;">Delete</label>
                                    <label class="gpLabel2" style="float:right;">Edit</label> 
                                </div>
                            </div>
                        </div>


                        <div class="col-lg-4 col-md-6">
                            <div class="checkout__order">
                                <h4>Your Account</h4>
                                <div class="checkout__order__products"><a href="account.aspx">Account Details</a></div>
                                <div class="checkout__order__products"><a href="orders.aspx">Orders</a></div>                           
                                <div class="checkout__order__products"><a href="shoppinglist.aspx">My Shopping List</a></div>
                                <div class="checkout__order__products"><a href="home.aspx" id="A1" runat="server" onserverclick="logout_Click">Logout</a></div>
                            </div>
                        </div>

                    </div>
<%--                </form>--%>
            </div>
        </div>
    </section>
</asp:Content>
