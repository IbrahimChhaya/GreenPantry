<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="GreenPantryFrontend.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

    <!-- Checkout Section Begin -->
    <section class="checkout spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h6><span class="icon_tag_alt"></span> Have a coupon? <a href="#">Click here</a> to enter your code
                    </h6>
                </div>
            </div>
            <div class="checkout__form" runat="server">
                                <h4>Billing Details</h4>
                <form action="#" runat="server">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="checkout__input">
                                       
                                    </div>
                                </div>
                            </div>



                            <div class="checkout__input">
                                <p>Address<span>*</span></p>
                                <input type="text" placeholder="Street Address" class="checkout__input__add" runat="server" id ="Line1">
                                <input type="text" placeholder="Apartment, suite, unite ect (optinal)" runat="server" id ="Line2">
                            </div>
                             <div class="checkout__input">
                                <p>Suburb<span>*</span></p>
                                <input type="text" placeholder ="Suburb" class="single-input" runat="server" id ="suburb">
                            </div>
                            <div class="checkout__input">
                                <p>Town/City<span>*</span></p>
                                <input type="text" placeholder="Town" class ="single-input" runat="server" id ="town">
                            </div>
                            <div class="checkout__input">
                                <p>Province<span>*</span></p>

                                <input List="Provinces" name="Province" id="Province">
                                <datalist id="Provinces">
                                 <option value="Eastern Cape">
                                 <option value="Free State">
                                 <option value="Gauteng">
                                 <option value="KwaZulu-Natal">
                                 <option value="Limpopo">
                                 <option value="Mpumalanga">
                                 <option value="Northern Cape">
                                 <option value="North West">
                                 <option value="Western Cape">
                                 </datalist>
                            </div>

                            <div class="checkout__input">
                                <p>Postcode / ZIP<span>*</span></p>
                                <input type="text" placeholder="Postcode" class="single-input" runat="server" id="postcode">
                            </div>
                            <div class="row">
                                <div class="col-lg-6">

                                </div>
                            </div>
                            
                           <!-- <p> <div class="checkout__input__checkbox">
                                <label for="diff-acc">
                                    Ship to a different address?
                                    <input type="checkbox" id="diff-acc">
                                    <span class="checkmark"></span>
                                </label>
                            </div> </p> -->
                            <div class="checkout__input">
                                <p>Order notes<span>*</span></p>
                                <input type="text"
                                    placeholder="Notes about your order, e.g. special notes for delivery." class ="single-input" runat="server" id="order">
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="checkout__order">
                                <h4>Your Order</h4>
                                <div class="checkout__order__products">Products <span>Total</span></div>
                                <ul>
                                    <li>Vegetable’s Package <span>$75.99</span></li>
                                    <li>Fresh Vegetable <span>$151.99</span></li>
                                    <li>Organic Bananas <span>$53.99</span></li>
                                </ul>
                                <div class="checkout__order__subtotal">Subtotal <span>$750.99</span></div>
                                <div class="checkout__order__total">Total <span>$750.99</span></div>
                                
                                <p>Lorem ipsum dolor sit amet, consectetur adip elit, sed do eiusmod tempor incididunt
                                    ut labore et dolore magna aliqua.</p>
                                
                                <asp:Button ID="Submit" Text="PLACE ORDER" runat="server" class="site-btn" OnCLick="Submit_Click" />
                               
                            </div>
                        </div>
                    </div>

                        <div class="checkout__input">
                            <asp:Label ID="error" runat="server" Text="" visible="false" ></asp:Label>
                        </div>
                </form>
            </div>
        </div>
    </section>
    <!-- Checkout Section End -->
    </asp:Content>