<%@ Import Namespace="SignificantTradeSSRepository"%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

 <fieldset>
                <legend><asp:Label ID="lblReviewsList" runat="server" Text="<%$Resources:SigTrade, lblAccountFormLegend%>"></asp:Label></legend>
                
                <p> <span class="red">*</span> indicates a required field.</p>
                <p>
                    <label for="first_name"><asp:Label ID="Label1" runat="server" Text="<%$Resources:SigTrade, lblAccountFormFirstName%>"></asp:Label>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("first_name", null, new { @class = "text required" })%>
                    <%= Html.ValidationMessage("first_name") %>
                </p>
              <p>
                    <label for="last_name"><asp:Label ID="Label2" runat="server" Text="<%$Resources:SigTrade, lblAccountFormLastName%>"></asp:Label>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("last_name", null, new { @class = "text required" })%>
                    <%= Html.ValidationMessage("last_name") %>
                </p>
                <% if (!(bool)ViewData["edit"])
                   { %>
     
                <p>
                    <label for="username"><asp:Label ID="Label3" runat="server" Text="<%$Resources:SigTrade, lblAccountFormUserName%>"></asp:Label>:</label> <span class="red">*</span><br />
                    <%= Html.TextBox("username", null, new { @class = "title required" }) %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                 <% } else{ %>
                    <input type="hidden" name="username" id="name" value="<%=ViewData["username"]%>" />       
                <% }%>

                <p>
                    <label for="email"><asp:Label ID="Label4" runat="server" Text="<%$Resources:SigTrade, lblAccountFormEmail%>"></asp:Label>:<%--Not required </label> <span class="red">*</span>--%><br />
                    <%= Html.TextBox("email", null, new { @class = "text email" })%>
                    <%--<%= Html.ValidationMessage("email") %>--%>
                </p>
                
                <% if (!(bool)ViewData["edit"]) { %>
                <p>
                    <label for="password"><asp:Label ID="Label5" runat="server" Text="<%$Resources:SigTrade, lblAccountFormPassword%>"></asp:Label>:</label> <a class="tooltip" href="#" title="Password| Please note, passwords must be a minimum of 6 characters."><img src="../../Content/images/icons/information.png" /></a><br />
                    <%= Html.Password("password", null, new { @class = "text required password", minlength = "6" })%>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <label for="confirmPassword"><asp:Label ID="Label6" runat="server" Text="<%$Resources:SigTrade, lblAccountFormConfirmPassword%>"></asp:Label>:</label> <span class="red">*</span><br />
                    <%= Html.Password("confirmPassword", null, new { @class = "text required", equalTo = "#password" })%>
                    <%= Html.ValidationMessage("confirmPassword") %>
                </p>
                
               <% } %>
                <div style="margin-bottom:1.5em;">                
                    <img src="../../Content/images/icons/house.png" /> <a href="#" id="advanced_reg_link"><asp:Label ID="Label7" runat="server" Text="<%$Resources:SigTrade, lblAccountFormContactInfo%>"></asp:Label></a> <span class="quiet">(<asp:Label ID="Label8" runat="server" Text="<%$Resources:SigTrade, lblAccountFormOptional%>"></asp:Label>)</span>
                </div>
                
                <div id="advanced_reg" <% if (!(bool)ViewData["edit"]){ %> style="display:none;" <% } %> >   
                <p>
                    <label for="organization"><asp:Label ID="Label17" runat="server" Text="<%$Resources:SigTrade, lblAccountFormOrganization%>"></asp:Label>:</label> <br />
                    <%= Html.TextBox("organization", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("organization")%>
                </p>
                
                <p>
                    <label for="address_1"><asp:Label ID="Label9" runat="server" Text="<%$Resources:SigTrade, lblAccountFormAddress1%>"></asp:Label>:</label> <br />
                    <%= Html.TextBox("address_1", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("address_1")%>
                </p>
                
                <p>
                    <label for="address_2"><asp:Label ID="Label10" runat="server" Text="<%$Resources:SigTrade, lblAccountFormAddress2%>"></asp:Label>:</label><br />
                    <%= Html.TextBox("address_2", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("address_2")%>
                </p>
                
                <p>
                    <label for="address_3"><asp:Label ID="Label11" runat="server" Text="<%$Resources:SigTrade, lblAccountFormAddress3%>"></asp:Label>:</label><br />
                    <%= Html.TextBox("address_3", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("address_3")%>
                </p>
                
                <p>
                    <label for="town/city"><asp:Label ID="Label12" runat="server" Text="<%$Resources:SigTrade, lblAccountFormTownCity%>"></asp:Label>:</label><br />
                    <%= Html.TextBox("town", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("town")%>
                </p>
                
			   <p>
                    <label for="state"><asp:Label ID="Label13" runat="server" Text="<%$Resources:SigTrade, lblAccountFormStateCounty%>"></asp:Label>:</label><br />
                    <%= Html.TextBox("state", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("state")%>
                </p>
                
                  <p>
                    <label for="postcode"><asp:Label ID="Label14" runat="server" Text="<%$Resources:SigTrade, lblAccountFormPostcode%>"></asp:Label>:</label><br />
                    <%= Html.TextBox("postcode", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("postcode")%>
                </p>
                
                 <p>
                    <label for="telephone"><asp:Label ID="Label15" runat="server" Text="<%$Resources:SigTrade, lblAccountFormTelephone%>"></asp:Label>:</label><br />
                    <%= Html.TextBox("telephone", null, new { @class = "text" })%>
                    <%= Html.ValidationMessage("telephone")%>
                </p>
			  
			  
			    <p>
			    <label for="country_id"><asp:Label ID="Label16" runat="server" Text="<%$Resources:SigTrade, lblAccountFormCountry%>"></asp:Label>:</label><br />
			    <%= Html.DropDownList("country_id", (SelectList)ViewData["countries"])%>
			    
			    </p>
			  
			  
			  </div>
			    <!--<add name="country_id" type="System.Int32" />-->
			    <hr />
                
                <p>
                    <input type="submit" value='<asp:Literal id="Literal1" Text="<%$Resources:SigTrade, lblAccountFormRegister%>" runat="server"/>' />
                </p>
            </fieldset>
