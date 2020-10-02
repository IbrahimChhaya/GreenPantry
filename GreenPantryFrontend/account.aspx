<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="GreenPantryFrontend.account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="breadcrumb__text">
                        <h2>Account</h2>
                        <div class="breadcrumb__option">
                            <a href="./home.aspx">Home</a>
                            <span>Account</span>
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
            <div class="checkout__form" runat="server">
                <h4>Account Details</h4>
                <form action="#" runat="server">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="checkout__input">
                                    </div>
                                </div>
                            </div>
                            <asp:Label ID="error" Font-Size="14px" Text="An error has occurred" runat="server" Visible="false" />
                            <div class="checkout__input">
                                <p>Name</p>
                                <input type="text" placeholder="First Name"  runat="server" id="Name">
                            </div>
                            <div class="checkout__input">
                                <p>Surname</p>
                                <input type="text" placeholder="Last Name" runat="server" id="Surname">
                            </div>
                            <div class="checkout__input">
                                <p>Email</p>
                                <input type="Email" placeholder="john123@gmail.com" runat="server" id="Email1">
                            </div>
                            <div class="checkout__input">
                                <p>Phone Number</p>
                                <input type="tel" placeholder="Must be 10 digits" runat="server" id="PhoneNumber1">
                            </div>
                            <asp:Button ID="Submit" Text="Update Account" runat="server" class="site-btn"  OnCLick="Submit_Click" />
                        </div>
                        
                        <div class="col-lg-4 col-md-6">
                            <div class="checkout__order">
                                <h4>Your Account</h4>
                                <div class="checkout__order__products"><a href="account.aspx">Account Details</a></div>
                                <div class="checkout__order__products"><a href="orders.aspx">Orders</a></div>
                                <div class="checkout__order__products"><a href="home.aspx" id="A1" runat="server" onserverclick="logout_Click">Logout</a></div>
                            </div>
                        </div>

                        <div class="col-lg-8 col-md-6">
                        <br />
                        <br />
                        <br />
                            <h4>Update Password</h4>
                            <div class="checkout__input">
                                <p>Current Password</p>
                                <input type="Password" placeholder="Current Password" runat="server" id="oldPass">
                            </div>
                            <div class="checkout__input">
                                <p>New Password</p>
                                <input type="Password" placeholder="New Password" runat="server" id="newPass">
                            </div>
                            <div class="checkout__input">
                                <p>Confirm New Password</p>
                                <input type="Password" placeholder="Confirm New Password" runat="server" id="confirmPass">
                            </div>
                            <asp:Button ID="updatePass" Text="Update Password" runat="server" class="site-btn"  OnCLick="updatePass_Click" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </section>
</asp:Content>
