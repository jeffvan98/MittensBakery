# Welcome
Welcome to Mittens Bakery.  

# Overview
This project is comprised of three sytems:
1. Product Management
2. Sales Management
3. Shared Services

![Architecture Diagram](/bin/Architecture.png)

Product Management is a small database based on a Products data model described by Len Silverston in ["The Data Model Resource Book."](https://www.wiley.com/en-us/The+Data+Model+Resource+Book%2C+Volume+1%3A+A+Library+of+Universal+Data+Models+for+All+Enterprises%2C+Revised+Edition-p-9780471380238)  It is supported by a small GraphQL API built with dotnet and the [Hot Chocolate](https://chillicream.com/) library providd by [ChilliCream](https://chillicream.com/).

Sales Management is very similar to Product Management.  However, it is based on a Sales Order data model, also described by Len Silverston.  Like Product Management, Sales Management is supported by a small GraphQL API.

Shared Services are comprised of two [Azure Logic Apps](https://learn.microsoft.com/en-us/azure/logic-apps/logic-apps-overview) that are used to synchronize data in between Product Management and Sales Management.  The first Logic App monitors Product Management on a recurring basis, looking for changes in Product data.  If it finds a change, then it records the change in [Azure Service Bus](https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview).  There, the second Logic App is configured to react to this data and update the corresponding product table in the Sales Management system.