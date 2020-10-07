<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="checkout2.aspx.cs" Inherits="GreenPantryFrontend.checkout2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
    <link rel="stylesheet" type="text/css" href="css/datePicker.css">
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
            <div class="checkout__form">
                <h4>Billing Details</h4>
                <form action="#" runat="server">
                    <div class="row">
                        <div class="col-lg-8 col-md-6">

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="checkout__input">
                                        
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="checkout__input">
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="checkout__input">
                                <p>Address<span>*</span></p>
                                <input type="text" placeholder="Street Address" class="checkout__input__add" id="line1" runat="server">
                                <input type="text" placeholder="Apartment, suite, unit, ect (optional)" id="line2" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Suburb<span>*</span></p>
                                <input type="text" placeholder="Suburb" id="suburb" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Town/City<span>*</span></p>
                                <input type="text" placeholder="Town or City" id="town" runat="server">
                            </div>
                            <div class="checkout_input">
                                <p style="color: #1c1c1c;margin-bottom: 20px;">Province<span>*</span></p>
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
                                <p>Postcode / ZIP<span>*</span></p>
                                <input type="text" Placeholder="Postal Code" id="postcode" runat="server">
                            </div>

                            <div class="checkout__input">
                                <p>Phone Number<span>*</span></p>
                                <input type="number" Placeholder="Phone Number" id="number" runat="server">
                            </div>

                            <div class="checkout__input">
                                <p>Order notes<span>*</span></p>
                                <input type="text"
                                    placeholder="Notes about your order, e.g. special notes for delivery." id="notes" runat="server">
                            </div>

                            <div class="checkout__input">
                                <p>Delivery Date Time<span>*</span></p>
                                <div class="dateTimePicker">
                                    <input type="text" runat="server" id="dateTimeID" data-input>
                                    <a class="input-button" title="toggle"data-toggle>
                                        <i class="icon-calendar"></i>
                                    </a>
                                </div>
                            </div>

<script>
    flatpickr(".dateTimePicker",
        {
            enableTime: true,
            dateFormat: "d-m-Y H:i",
            time_24hr: true,
            wrap: true
        });
</script>

                        </div>

                        <div class="col-lg-4 col-md-6">
                            
                            <div class="checkout__order">
                                <h4>Green Points</h4>
                                <label class="gpLabel">Green Points available in Rands:</label><p class="gpP" id="pointsAvailable" runat="server">R500</p>
                                <label class="gpLabel2">Amount you'd like to spend:</label> 
                                <p class="gpP">R<input type="text" id="pointsUsed" runat="server" class="gpInput" value="0"></p>
                                <asp:Button text="NOT ENOUGH POINTS" class="noPoints-btn" ID="noPoints" runat="server" Visible="false"></asp:Button>
                                <asp:Button text="REDEEM" class="apply-btn" ID="Redeem" runat="server" OnClick="btnRedeem_Click"></asp:Button>
                                <label id="pointsError" runat="server" visible="false">bruh</label>
                            </div>

                            <br />
                            <br />

                            <div class="checkout__order">
                                <h4>Your Order</h4>
                                <div class="checkout__order__products">Products <span>Total</span></div>
                                <ul id="checkoutItems" runat="server">
                                    <li>Vegetable’s Package <span>$75.99</span></li>
                                    <li>Fresh Vegetable <span>$151.99</span></li>
                                    <li>Organic Bananas <span>$53.99</span></li>
                                </ul>
                                <div class="checkout__order__subtotal" id="orderSubtotal" runat="server">Subtotal <span>$750.99</span></div>
                                <div id="pointsDisplay" runat="server">
                                    <!--<div class="checkout__order__userpoints" id="orderPoints" runat="server">Points <span>Rhella</span></div>-->
                                </div>
                                <div class="checkout__order__shipping" id="orderVAT" runat="server">VAT <span>R60</span></div>
                                <div class="checkout__order__shipping" id="orderShipping" runat="server">Delivery <span>R60</span></div>
                                <div class="checkout__order__total" id="orderTotal" runat="server">Total <span>$750.99</span></div>

                                <asp:Label ID="error" Text="An error has occurred" runat="server" Visible="false" />
                                <asp:Button text="PLACE ORDER" class="placeOrder" ID="btnOrder" runat="server" OnClick="btnOrder_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </section>
    <!-- Checkout Section End -->
    </asp:Content>