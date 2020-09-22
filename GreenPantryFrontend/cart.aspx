<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="GreenPantryFrontend.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="breadcrumb__text">
                        <h2>Shopping Cart</h2>
                        <div class="breadcrumb__option">
                            <a href="./home.aspx">Home</a>
                            <span>Shopping Cart</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    <!-- Shoping Cart Section Begin -->
    <section class="shoping-cart spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__table">
                        <table>
                            <thead>
                                <tr>
                                    <th class="shoping__product">Products</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Total</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody  runat="server" ID="tablerow">

                               <%-- <tr>
                                    <td class="shoping__cart__item">
                                        <img src="img/cart/cart-1.jpg" alt="">
                                        <h5>Vegetable’s Package</h5>
                                    </td>
                                    <td class="shoping__cart__price">
                                        $55.00
                                    </td>
                                    <td class="shoping__cart__quantity">
                                        <div class="quantity">
                                            <div class="pro-Cartqty">
                                                <span class="dec qtybtn" runat ="server" id="decQty" ><a href="" onclick="decQty_Click(1,2)">-</a></span>
                                                <input type="text" value="1" runat ="server"  id="item_qty" oninput="decreaseQty()">
                                            </div>
                                        </div>
                                    </td>
                                    <td class="shoping__cart__total">
                                        $110.00
                                    </td>
                                    <td class="shoping__cart__item__close">
                                        <span class="icon_close"></span>
                                    </td>
                                </tr>--%>
                                <asp:Label ID="pID" runat="server" Text="Incorrect Password or Username" visible="false" ></asp:Label>
<%--                              <span class="dec qtybtn" runat ="server" id="decQty" onclick="decQty_Click" href="cart.aspx">-</span>--%>
<%--                                <div class="quantity"><div class="pro-qty"><input type ="text" value=" " runat="server" id="item_qty"></div></div>--%>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="shoping__cart__btns" >
                        <a href="categories.aspx?CategoryID=1" class="primary-btn cart-btn" runat="server" id="Cart_continue">CONTINUE SHOPPING</a>
                        <a href="cart.aspx" class="primary-btn cart-btn cart-btn-right" runat="server" id="update" onclick="update_Click"><span class="icon_loading"></span>
                            Update Cart</a>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="shoping__continue">
                        <div class="shoping__discount">
                            <h5>Discount Codes</h5>
                            <form action="#">
                                <input type="text" placeholder="Enter your coupon code">
                                <button type="submit" class="site-btn">APPLY COUPON</button>
                            </form>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="shoping__checkout" runat="server" ID="cartTotal">
                      
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Shoping Cart Section End -->
    </asp:Content>