<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="GreenPantryFrontend.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="breadcrumb__text">
                        <h2>Checkout</h2>
                        <div class="breadcrumb__option">
                            <a href="./home.aspx">Home</a>
                            <span>Checkout</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->
<body>
    <form id="form1" runat="server">
        <div class ="Accounts">
             <p>Name<span>*</span></p>
                <input type="text" placeholder="First Name"  runat="server" id ="Line1">
        </div>
        <div class ="Accounts">
             <p>Surname<span>*</span></p>
                <input type="text" placeholder="Last Name" runat="server" id ="Line2">
         </div>
         <div class ="Accounts">
             <p>Email<span>*</span></p>
                <input type="Email" placeholder="john123@gmail.com" runat="server" id ="Email1">
         </div>
        <div class ="Accounts">
             <p>Password<span>*</span></p>
                <input type="Password" placeholder="Password" runat="server" id ="Password1">
         </div>
        <div class ="Accounts">
             <p>Phone Number<span>*</span></p>
                <input type="tel" placeholder="Must be 10 digits" runat="server" id ="PhoneNumber1">
         </div>

        <asp:Button Text="Submit" runat="server"/>
    </form>
</body>
</html>
