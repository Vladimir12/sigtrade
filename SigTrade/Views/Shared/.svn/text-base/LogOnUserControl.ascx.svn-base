<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%
    if (Request.IsAuthenticated) {
%>
        <!--Welcome <b><%= Html.Encode(Page.User.Identity.Name) %> -->
        <%= Html.ActionLink(Page.User.Identity.Name + "'s Account", "", "") %>
        
        <ul>
             <% if (Roles.IsUserInRole("Administrator"))
             {%>
            <li><%=Html.ActionLink("Site Admin", "index", "Account")%>
                <ul>
                    <li><%=Html.ActionLink("Users", "index", "Account")%>                        
                        <ul>
                            <li><%=Html.ActionLink("List", "index", "Account")%></li>
                            <li><%=Html.ActionLink("New", "Register", "Account")%></li>     
                        </ul>
                    </li>
                    <li><%=Html.ActionLink("Roles", "Index", "Role")%>                        
                        <ul>
                            <li><%=Html.ActionLink("List Roles", "Index", "Role")%></li>
                               
                        </ul>
                    </li> 
                    
                    <li><%=Html.ActionLink("Phases", "Index", "Phases")%>                        
                        <ul>
                            <li><%=Html.ActionLink("List Phases", "Index", "Phases")%></li>
                            <li><%=Html.ActionLink("New Phase", "Create", "Phases")%></li>     
                        </ul>
                    </li> 
                  <%--  <li><%=Html.ActionLink("Committees", "Index", "Committees")%>                        
                        <ul>
                            <li><%=Html.ActionLink("List Committees", "Index", "Committees")%></li>
                            <li><%=Html.ActionLink("New Committee", "Create", "Committees")%></li>     
                        </ul>
                    </li>       --%>
                    
                     <li><%=Html.ActionLink("Committees", "Index", "Meetings")%>                        
                        <ul>
                            <li><%=Html.ActionLink("List Committees", "Index", "Meetings")%></li>
                            <li><%=Html.ActionLink("New Committee", "Create", "Meetings")%></li>     
                        </ul>
                    </li> 
                    
                     <li><%=Html.ActionLink("Email Templates", "Index", "MessageTemplate")%>                        
                        <ul>
                            <li><%=Html.ActionLink("List Templates", "Index", "MessageTemplate")%></li>
                            <li><%=Html.ActionLink("New Template", "Create", "MessageTemplate")%></li>         
                            <li><%=Html.ActionLink("Send Alerts", "SendAlerts", "Message",new {},new {TARGET = "_blank"})%></li>     
                        </ul>
                    </li>        
                    
                     <li><%=Html.ActionLink("SendEmail", "SendTestEmail", "Message")%>                        
                        <ul>
                            <li><%=Html.ActionLink("Send a test emails", "SendTestEmail", "Message")%></li>
                               
                        </ul>
                    </li>  
                    
                    <%-- <li><%=Html.ActionLink("Report", "Index", "Report")%>                        
                        <ul>
                            <li><%=Html.ActionLink("Summary by Country","Index", "Report")%></li>
                            <li><%=Html.ActionLink("Summary by Species", "TestReport", "Report")%></li>
                            <li><%=Html.ActionLink("Summary by Level of Concern", "GenericReport", "Report")%></li>                                                       
                        </ul>
                    </li>  --%>
                    
                    
                </ul>
            </li>
            <%
              }
              %>
        
        
            <li><%=Html.ActionLink("Edit Password", "ChangePassword", "Account")%></li> 
            <li><%= Html.ActionLink("Log Off", "LogOff", "Account") %></li>
        </ul>
<%
    }
    else {
%> 
        <%= Html.ActionLink("Log On", "LogOn", "Account") %>
<%
    }
%>
