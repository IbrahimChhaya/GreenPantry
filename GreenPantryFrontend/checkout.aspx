<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="GreenPantryFrontend.checkout2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
    <link rel="stylesheet" type="text/css" href="css/datePicker.css">
    <link rel="stylesheet" href="css/creditCard.css" type="text/css" />

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
            <div class="checkout__form">
                <h4>Address Details</h4>
                <p id="addressSaved" runat="server" visible="false">This address will be saved to your Address Book</p>
<%--                <form action="#" runat="server">--%>
                    <div class="row">
                        <div class="col-lg-8 col-md-6"  id="newAddress" runat="server" visible="false">

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
                                <p>Give This Address A Name</p>
                                <input type="text" placeholder="Home/Business" id="type" runat="server" required>
                            </div>

                            <div class="checkout__input">
                                <p>Address<span>*</span></p>
                                <input type="text" placeholder="Street Address" class="checkout__input__add" id="line1" runat="server" required>
                                <input type="text" placeholder="Apartment, suite, unit, ect (optional)" id="line2" runat="server">
                            </div>
                            <div class="checkout__input">
                                <p>Suburb<span>*</span></p>
                                <input type="text" placeholder="Suburb" id="suburb" runat="server" required>
                            </div>
                            <div class="checkout__input">
                                <p>Town/City<span>*</span></p>
                                <input type="text" placeholder="Town or City" id="town" runat="server" required>
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
                                <input type="text" Placeholder="Postal Code" id="postcode" runat="server" required>
                            </div>

                            <div class="checkout__input">
                                <p>Phone Number<span>*</span></p>
                                <input type="number" Placeholder="Phone Number" id="phone" runat="server" required>
                            </div>

                            <div class="checkout__input">
                                <p>Order notes<span>*</span></p>
                                <input type="text"
                                    placeholder="Notes about your order, e.g. special notes for delivery." id="notes" runat="server" required>
                            </div>
                        </div>



                    <div class="col-lg-8 col-md-6">
                        <div class="checkout__order" id="oldAddress" runat="server" visible="true">
                            <div>
                                <label><b>Home</b> <span class='badge badge-success'>PRIMARY</span></label>
                            </div>
                            <div>
                                <label>1 Smith road</label>
                            </div>
                            <div>
                                <label>Bedfordview, Johannesburg, 2007</label>
                                <label class="gpLabel2" style="float:right;">Delete</label>
                                <label class="gpLabel2" style="float:right;">Edit</label>
                                <label class="gpLabel2" style="float:right;">Change Primary Address</label> 
                            </div>
                        </div>

                            <br />
                            <div class="checkout__input">
                                <h4>Delivery Date</h4>
                                <input type="text" class="dateTimeID" runat="server" id="dateTimeID1" placeholder="Select date for delivery" required>
                            </div>
                    <!--</div>

                             -----------------------hope this works ---------------------------- 
                        <div class="col-lg-8 col-md-6">-->
                        <br />
                        <br />
                            <h4>Payment Information</h4>
                            
                            <div class="cardcontainer preload">
                                <div class="creditcard">
                                    <div class="front">
                                        <div id="ccsingle"></div>
                                        <svg version="1.1" id="cardfront" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
                                            x="0px" y="0px" viewBox="0 0 750 471" style="enable-background:new 0 0 750 471;" xml:space="preserve">
                                            <g id="Front">
                                                <g id="CardBackground">
                                                    <g id="Page-1_1_">
                                                        <g id="amex_1_">
                                                            <path id="Rectangle-1_1_" class="lightcolor grey" d="M40,0h670c22.1,0,40,17.9,40,40v391c0,22.1-17.9,40-40,40H40c-22.1,0-40-17.9-40-40V40
                                                    C0,17.9,17.9,0,40,0z" />
                                                        </g>
                                                    </g>
                                                    <path class="darkcolor greydark" d="M750,431V193.2c-217.6-57.5-556.4-13.5-750,24.9V431c0,22.1,17.9,40,40,40h670C732.1,471,750,453.1,750,431z" />
                                                </g>
                                                <text transform="matrix(1 0 0 1 60.106 295.0121)" id="svgnumber" class="st2 st3 st4">0123 4567 8910 1112</text>
                                                <text transform="matrix(1 0 0 1 54.1064 428.1723)" id="svgname" class="st2 st5 st6">JOHN DOE</text>
                                                <text transform="matrix(1 0 0 1 54.1074 389.8793)" class="st7 st5 st8">cardholder name</text>
                                                <text transform="matrix(1 0 0 1 479.7754 388.8793)" class="st7 st5 st8">expiration</text>
                                                <text transform="matrix(1 0 0 1 65.1054 241.5)" class="st7 st5 st8">card number</text>
                                                <g>
                                                    <text transform="matrix(1 0 0 1 574.4219 433.8095)" id="svgexpire" class="st2 st5 st9">01/23</text>
                                                    <text transform="matrix(1 0 0 1 479.3848 417.0097)" class="st2 st10 st11">VALID</text>
                                                    <text transform="matrix(1 0 0 1 479.3848 435.6762)" class="st2 st10 st11">THRU</text>
                                                    <polygon class="st2" points="554.5,421 540.4,414.2 540.4,427.9 		" />
                                                </g>
                                                <g id="cchip">
                                                    <g>
                                                        <path class="st2" d="M168.1,143.6H82.9c-10.2,0-18.5-8.3-18.5-18.5V74.9c0-10.2,8.3-18.5,18.5-18.5h85.3
                                                c10.2,0,18.5,8.3,18.5,18.5v50.2C186.6,135.3,178.3,143.6,168.1,143.6z" />
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <rect x="82" y="70" class="st12" width="1.5" height="60" />
                                                        </g>
                                                        <g>
                                                            <rect x="167.4" y="70" class="st12" width="1.5" height="60" />
                                                        </g>
                                                        <g>
                                                            <path class="st12" d="M125.5,130.8c-10.2,0-18.5-8.3-18.5-18.5c0-4.6,1.7-8.9,4.7-12.3c-3-3.4-4.7-7.7-4.7-12.3
                                                    c0-10.2,8.3-18.5,18.5-18.5s18.5,8.3,18.5,18.5c0,4.6-1.7,8.9-4.7,12.3c3,3.4,4.7,7.7,4.7,12.3
                                                    C143.9,122.5,135.7,130.8,125.5,130.8z M125.5,70.8c-9.3,0-16.9,7.6-16.9,16.9c0,4.4,1.7,8.6,4.8,11.8l0.5,0.5l-0.5,0.5
                                                    c-3.1,3.2-4.8,7.4-4.8,11.8c0,9.3,7.6,16.9,16.9,16.9s16.9-7.6,16.9-16.9c0-4.4-1.7-8.6-4.8-11.8l-0.5-0.5l0.5-0.5
                                                    c3.1-3.2,4.8-7.4,4.8-11.8C142.4,78.4,134.8,70.8,125.5,70.8z" />
                                                        </g>
                                                        <g>
                                                            <rect x="82.8" y="82.1" class="st12" width="25.8" height="1.5" />
                                                        </g>
                                                        <g>
                                                            <rect x="82.8" y="117.9" class="st12" width="26.1" height="1.5" />
                                                        </g>
                                                        <g>
                                                            <rect x="142.4" y="82.1" class="st12" width="25.8" height="1.5" />
                                                        </g>
                                                        <g>
                                                            <rect x="142" y="117.9" class="st12" width="26.2" height="1.5" />
                                                        </g>
                                                    </g>
                                                </g>
                                            </g>
                                            <g id="Back">
                                            </g>
                                        </svg>
                                    </div>
                                    <div class="back">
                                        <svg version="1.1" id="cardback" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
                                            x="0px" y="0px" viewBox="0 0 750 471" style="enable-background:new 0 0 750 471;" xml:space="preserve">
                                            <g id="Front">
                                                <line class="st0" x1="35.3" y1="10.4" x2="36.7" y2="11" />
                                            </g>
                                            <g id="Back">
                                                <g id="Page-1_2_">
                                                    <g id="amex_2_">
                                                        <path id="Rectangle-1_2_" class="darkcolor greydark" d="M40,0h670c22.1,0,40,17.9,40,40v391c0,22.1-17.9,40-40,40H40c-22.1,0-40-17.9-40-40V40
                                                C0,17.9,17.9,0,40,0z" />
                                                    </g>
                                                </g>
                                                <rect y="61.6" class="st2" width="750" height="78" />
                                                <g>
                                                    <path class="st3" d="M701.1,249.1H48.9c-3.3,0-6-2.7-6-6v-52.5c0-3.3,2.7-6,6-6h652.1c3.3,0,6,2.7,6,6v52.5
                                            C707.1,246.4,704.4,249.1,701.1,249.1z" />
                                                    <rect x="42.9" y="198.6" class="st4" width="664.1" height="10.5" />
                                                    <rect x="42.9" y="224.5" class="st4" width="664.1" height="10.5" />
                                                    <path class="st5" d="M701.1,184.6H618h-8h-10v64.5h10h8h83.1c3.3,0,6-2.7,6-6v-52.5C707.1,187.3,704.4,184.6,701.1,184.6z" />
                                                </g>
                                                <text transform="matrix(1 0 0 1 621.999 227.2734)" id="svgsecurity" class="st6 st7">985</text>
                                                <g class="st8">
                                                    <text transform="matrix(1 0 0 1 518.083 280.0879)" class="st9 st6 st10">security code</text>
                                                </g>
                                                <rect x="58.1" y="378.6" class="st11" width="375.5" height="13.5" />
                                                <rect x="58.1" y="405.6" class="st11" width="421.7" height="13.5" />
                                                <text transform="matrix(1 0 0 1 59.5073 228.6099)" id="svgnameback" class="st12 st13">John Doe</text>
                                            </g>
                                        </svg>
                                    </div>
                                </div>
                            </div>
                            <div class="form-container">
                                <div class="field-container">
                                    <label class="cardlabel" for="name">Name</label>
                                    <input id="name" class="cardinput" maxlength="20" type="text" required><span id="generatecard" style="display:none;">generate random</span>
                                </div>
                                <div class="field-container">
                                    <label class="cardlabel" for="cardnumber">Card Number</label>
                                    <input class="cardinput" id="cardnumber" type="text" inputmode="numeric">
                                    <svg id="ccicon" class="ccicon" width="750" height="471" viewBox="0 0 750 471" version="1.1" xmlns="http://www.w3.org/2000/svg"
                                        xmlns:xlink="http://www.w3.org/1999/xlink">

                                    </svg>
                                </div>
                                <div class="field-container">
                                    <label class="cardlabel" for="expirationdate">Expiration (mm/yy)</label>
                                    <input class="cardinput" id="expirationdate" type="text" inputmode="numeric" >
                                </div>
                                <div class="field-container">
                                    <label class="cardlabel" for="securitycode">Security Code</label>
                                    <input class="cardinput" id="securitycode" type="text" inputmode="numeric" required>
                                </div>
                            </div>
                        </div>


                            <!-- -----------------------end hope this works ---------------------------- -->
                        
                    <div class="col-lg-4 col-md-6" id="sidebar" runat="server">
                            
                            <div class="checkout__order">
                                <h4>Green Points</h4>
                                <label class="gpLabel">Green Points available in Rands:</label><p class="gpP" id="pointsAvailable" runat="server">R500</p>
                                <label class="gpLabel2">Amount you'd like to spend:</label> 
                                <p class="gpP">R<input type="text" id="pointsUsed" runat="server" class="gpInput" value="0"></p>
                                <a class="noPoints-btn" id="noPoint" runat="server" visible="false">NOT ENOUGH POINTS</a>
                                <asp:Button text="REDEEM" class="apply-btn" ID="Redeem" runat="server" OnClick="btnRedeem_Click"></asp:Button>
                                <label id="pointsError" runat="server" visible="false">bruh</label>
                            </div>

                            <br />
                            <br />

                            <div class="checkout__order">
                                <h4>Your Order</h4>
                                <div class="checkout__order__products">Products <span>Amount</span></div>
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
<%--                </form>--%>
            </div>
        </div>
    </section>
    <!-- Checkout Section End -->
    </asp:Content>