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
                            <div class ="checkout__input">
                                <p>Name<span>*</span></p>
                                <input type="text" placeholder="First Name"  runat="server" id="Name">
                            </div>
                            <div class ="checkout__input">
                                <p>Surname<span>*</span></p>
                                <input type="text" placeholder="Last Name" runat="server" id="Surname">
                            </div>
                            <div class ="checkout__input">
                                <p>Email<span>*</span></p>
                                <input type="Email" placeholder="john123@gmail.com" runat="server" id ="Email1">
                            </div>
                            <div class ="checkout__input">
                                <p>Old Password<span>*</span></p>
                                <input type="Password" placeholder="Old Password" runat="server" id ="Password1">
                            </div>
                            <div class ="checkout__input">
                                <p>New Password<span>*</span></p>
                                <input type="Password" placeholder="New Password" runat="server" id ="Password2">
                            </div>
                            <div class ="checkout__input">
                                <p>Phone Number<span>*</span></p>
                                <input type="tel" placeholder="Must be 10 digits" runat="server" id ="PhoneNumber1">
                            </div>
                            <asp:Label ID="error" Text="An error has occurred" runat="server" Visible="false" />
                            <asp:Button ID="Submit" Text="Submit" runat="server" class="site-btn"  OnCLick="Submit_Click" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </section>
</asp:Content>
