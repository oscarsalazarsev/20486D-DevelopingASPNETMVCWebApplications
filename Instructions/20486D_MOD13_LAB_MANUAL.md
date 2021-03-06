# Module 13: Implementing Web APIs

# Lab: Implementing Web APIs

#### Scenario

You have been asked to create a web-based restaurant application for your organization's customers, you want 
to create a page showing all the Restaurant branches, enable to order a reservation for the selected restaurant branch, and add wanted ad page, also submit to a selected job.

You will create a server side Web API application and a client side MVC Core application calling Web API actions using HttpClient and jQuery.

#### Objectives

After completing this lab, you will be able to:

- Add actions to a Web API application.
- Call Web API actions using HttpClient.
- Call Web API actions using jQuery.

#### Lab Setup

Estimated Time: **60 minutes**

### Preparation Steps

1.	Ensure that you have cloned the **20486D** directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20486D-DevelopingASPNETMVCWebApplications/tree/master/Allfiles**)

### Exercise 1: Adding Actions and Call them using Microsoft Edge

#### Scenario

In this exercise, you will first add an action to a Web API application. You will then run the application and view the outcome. After that you will add an action gets a parameter and a post action to the Web API application.

The main tasks for this exercise are as follows:

1.	Add an action to a Web API application.

2.	Run the application.

3.	Add an action that gets a parameter to a Web API application.

4.	Run the application.

5.	Add a Post action to a Web API application.


#### Task 1: Add an action to a Web API application

1. Open the **Command Prompt** window using **Run as administrator**.

2. In the **Administrator: Command Prompt**, run the command **cd &lt;The location of Allfiles\Mod13\Labfiles\01_Restaurant_begin\Client folder on your machine&gt;**

3. Run the command **npm install**.

4. Close the **Command Prompt** window.

5. Open the **Restaurant.sln** file from the following location: **Allfiles\Mod13\Labfiles\01_Restaurant_begin**.

6. Create a new folder with the following information:

   - Project: **Server**
   - Folder name: **Controllers**
   
7. Create a new controller with the following information:
   - Controller name: **RestaurantBranchesController**
   - Template: **API Controller - Empty**
   - Folder: **Controllers**
   
8. In the **RestaurantBranchesController** class, add **using** statements for the following namespaces:
   - **Server.Data**
   - **Server.Models**

9. Create a new field with the following information:
   - Scope: **private**
   - Type: **RestaurantContext**
   - Name: **_context**

10.  Add a constructor with the following parameter:
     - Parameter: 
         - Type: **RestaurantContext** 
         - Name: **context**

11. In the **RestaurantBranchesController** constructor, initialize the **_context** field with the value of the **context** parameter.

12. Add a method for the **Get** action with the following information:
    - Scope: **public**
    - Return type: **ActionResult	&lt;List&lt;RestaurantBranch&gt;&gt;**
    - Name: **Get**

13. Annotate the **Get** action with the **HttpGet** attribute.

14. In the **Get** method, create a variable named **branches** of type **var** and assign it the value of the following LINQquery:

    - From: **r in _context.RestaurantBranches**
    - Orderby: **r.City**
    - Select: **r**
   
15. Return the **List&lt;RestaurantBranch&gt;** result using the **branches.ToList** method. 


#### Task 2: Run the application

1. Save all the changes.

2. In Solution Explorer, right-click **Server**, and then click **Set as StartUp Project**.

3. Start the application without debugging.
    >**Note:**  The browser displays the first restaurant in **JSON** format.

4. Close **Microsoft Edge**.

#### Task 3: Add an action that gets a parameter to a Web API application

1.  Create a new controller with the following information:
   - Controller name: **ReservationController**
   - Template: **API Controller - Empty**
   - Folder: **Controllers**
   
2. In the **ReservationController** class, add **using** statements for the following namespaces:
   - **Server.Data**
   - **Server.Models**
   
3. Create a new field with the following information:
   - Scope: **private**
   - Type: **RestaurantContext**
   - Name: **_context**

4.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **ReservationController** 
        - Name: **context**

5. In the **ReservationController** constructor, initialize the **_context** field with the value of the **context** parameter.

6. Add a method for the **GetById** action with the following information:
   - Scope: **public**
   - Return type: **ActionResult&lt;OrderTable&gt;**
   - Name: **GetById**
   - Parameter: 
        - Type: **int** 
        - Name: **id**

7. Annotate the **GetById** action with the **HttpGet** attribute.

8. In the **GetById** method, create a variable named **order ** of type **var** and assign it with the value of **_context.ReservationsTables.FirstOrDefault(p => p.Id == id)**.

9. Create an **IF** statement that checks that the value of the **order** varible is **null**. 

10. Inside the **IF** statement code block, return a **NotFoundResult** result using the **NotFound** method.

11. After the **IF** statement code block, return the **ActionResult&lt;OrderTable&gt;** result usig the **order** variable.

#### Task 4: Run the application

1. Save all the changes.

2. Start the application without debugging.

3. In **Microsoft Edge**, navigate to **http://localhost:[port]/api/Reservation/1**.
    >**Note:**  The browser displays the first restaurant in **JSON** format.

4. Close **Microsoft Edge**.


#### Task 5: Add a Post action to a Web API application

1. In the **ReservationController** constructor, add a method for the **Create** action with the following information:
   - Scope: **public**
   - Return type: **ActionResult&lt;OrderTable&gt;**
   - Name: **Create**
   - Parameter: 
        - Type: **OrderTable** 
        - Name: **orderTable**
        
2. Annotate the **Post** action with the **HttpPost** attribute.

3. Annotate the **Post** action with the **ProducesResponseType** attribute. Pass **201** and **Type = typeof(OrderTable)** as parameters to the **ProducesResponseType** attribute.

4. Annotate the **Post** action with the **ProducesResponseType** attribute. Pass **400** as a parameter to the **ProducesResponseType** attribute.

5. Create an **IF** statement that checks that the value of the **ModelState.IsValid** varible is **false**. 

6. Inside the **IF** statement code block, return a **BadRequestResult** result using the **BadRequest** method. Pass the **ModelState** property as a parameter to the **BadRequest** method.

7. After the **IF** statement code block, call the **Add** method of the **_context** field. Pass the **orderTable** property as a parameter to the **Add** method.

8. Call the **SaveChanges** method of the **_context** field. 

9. Return the **ActionResult&lt;OrderTable&gt** result usig the **CreatedAtAction** method. Pass **nameof(GetById)**,  **new { id = orderTable.Id }** and orderTable asparameters to the **CreatedAtAction** method.

>**Results** : After completing this exercise, you will be able to

### Exercise 2: Calling a Web API using Server-Side Code

#### Scenario

In this exercise, you will first configure HttpClient in the Startup.cs file. You will then create MVC controller and write httpClient get method. After that you will call Web API Service GET method. Finally, you will write httpClient post method and call Web API Service POST method and then run the application. 

The main tasks for this exercise are as follows:

1. Calling a Web API Service GET method.

2. Run the Application.

3. Calling a Web API Service POST method.

4. Run the Application.


#### Task 1: Calling a Web API Service GET method

1. In the **Startup** class, at the end of the **ConfigureServices** method, call the **AddHttpClient** method of the **services** parameter.

2. Create a new folder with the following information:

   - Project: **Client**
   - Folder name: **Controllers**
   
3. Create a new controller with the following information:
   - Controller name: **RestaurantController**
   - Template: **MVC Controller - Empty**
   - Folder: **Controllers**
   
4. In the **RestaurantController** class, add **using** statements for the following namespaces:
   - **System.Net.Http**
   - **Server.Models**

5. Remove the **Index** action with its content.

6. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClient**

7. Create a new field with the following information:
   - Scope: **private**
   - Type: **IEnumerable&lt;RestaurantBranch&gt;**
   - Name: **_restaurantBranches**

8.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClient**

9. In the **RestaurantController** constructor, initialize the **_httpClient** field with the value of the **httpClient** parameter.

10. Add a method for the **Index** action with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **Index**

11. In the **Index** method,  add a variable named **request** of type **var**. Initialize the **request** variable with the value of **new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantBranches")**.

12. Call the **Add** method of the **request.Header** property. Pass **"Accept"** and **"application/json"** as parameters to the **Add** method .

13. Add a variable named **client** of type **var**. Initialize the **client** variable with the value of **_httpClient.CreateClient()**.

14. Add a variable named **response** of type **var**. Initialize the **response** variable with the value of **await client.SendAsync(request)**.

15. Create an **IF** statement that checks that the value of the **response.IsSuccessStatusCode** is **TRUE**.

16. Inside the **IF** statement code block, assign the **_restaurantBranches** field with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;RestaurantBranch&gt;&gt;()**.
   
17. Return the **ViewResult** result using the **View** method. Pass **_restaurantBranches** as a parameter to the **View** method.

#### Task 2: Run the Application

1. View the contents of the **Index.cshtml** view.
    
2. Save all the changes.

3. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

4. Start the application without debugging.

5. In **Solution Explorer**, right-click **Server**, point to **Debug**, and then click **Start new instance**.
    >**Note:** The browser displays the **Index.cshtml** file content of the **RestaurantController**.
    
6. In the menu bar, click **Reservation**.
    >**Note:** We have not yet built the content of the page.

#### Task 3: Calling a Web API Service POST method

1. Create a new controller with the following information:
   - Controller name: **ReservationController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**
   
2. In the **ReservationController** class, add **using** statements for the following namespaces:
   - **Microsoft.AspNetCore.Mvc.Rendering**
   - **System.Net.Http**
   - **Server.Models**

3. Remove the **Index** action with its content.

4. Create a new field with the following information:
   - Scope: **private**
   - Type: **IHttpClientFactory**
   - Name: **_httpClient**

5. Create a new field with the following information:
   - Scope: **private**
   - Type: **IEnumerable&lt;RestaurantBranch&gt;**
   - Name: **_restaurantBranches**

6.  Add a constructor with the following parameter:
    - Parameter: 
        - Type: **IHttpClientFactory** 
        - Name: **httpClient**

7. In the **ReservationController** constructor, initialize the **_httpClient** field with the value of the **httpClient** parameter.

8. Add a method for the **Create** action with the following information:
   - Scope: **public**
   - Modifier: **async**
   - Return type: **Task&lt;IActionResult&gt;**
   - Name: **Create**
   
9. Annotate the **Create** action with the **HttpGet** attribute.

10. In the **Create** method, call the **PopulateRestaurantBranchesDropDownListAsync** method using the **await** keyword. 
   
11. Return the **Task&lt;IActionResult&gt;** result using the **View** method. 

12. Add a method for the **CreatePostAsync** action with the following information:
    - Scope: **public**
    - Modifier: **async**
    - Return type: **Task&lt;IActionResult&gt;**
    - Name: **CreatePostAsync**
   
13. Annotate the **CreatePostAsync** action with the **HttpPost** attribute.

14. Annotate the **CreatePostAsync** action with the **ActionName** attribute. Pass **"Create"** as a parameter to the **ActionName** attribute.

15. In the **CreatePostAsync** method, add a variable named **client** of type **var**. Initialize the **client** variable with the value of **_httpClient.CreateClient()**.

16. Add a variable named **response** of type **var**. Initialize the **response** variable with the value of **wait client.PostAsJsonAsync("http://localhost:54517/api/Reservation", orderTable)**.

17. Call the **EnsureSuccessStatusCode** method of the **response** variable.
   
18. Return the **Task&lt;IActionResult&gt;** result using the **RedirectToAction** method. Pass **nameof(ThankYou)** as a parameter to the **RedirectToAction** method.

19. Add a **PopulateRestaurantBranchesDropDownListAsync** method with the following information:
     - Scope: **private**
     - Modifier: **async**
     - Return type: **Task**
     - Name: **PopulateRestaurantBranchesDropDownListAsync**   
     - Parameter: 
         - Type: **int?** 
         - Name: **selectedBranch**
         - Defualt value: **null**   

20. In the **PopulateRestaurantBranchesDropDownListAsync** method, add a variable named **request** of type **var**. Initialize the **request** variable with the value of **new HttpRequestMessage(HttpMethod.Get, "http://localhost:54517/api/RestaurantBranches")**.

21. Call the **Add** method of the **request.Headers** property. Pass **"Accept"** and **"application/json"** as parameters to the **Add** method.

22. Add a variable named **client** of type **var**. Initialize the **client** variable with the value of **_httpClient.CreateClient()**.

23. Add a variable named **response** of type **var**. Initialize the **response** variable with the value of **await client.SendAsync(request)**.

24. Create an **IF** statement that checks that the value of the **response.IsSuccessStatusCode** varible is **true**. 

25. Inside the **IF** statement code block, assign the **_restaurantBranches** property with the value of **await response.Content.ReadAsAsync&lt;IEnumerable&lt;RestaurantBranch&gt;&gt;()**.

26. Assign the **RestaurantBranchId** property of the **ViewBag** field with the value of **new SelectList(_restaurantBranches, "Id", "City", selectedBranch)**.

27. Add a method for the **ThankYou** action with the following information:
   - Scope: **public**
   - Return type: **IActionResult**
   - Name: **ThankYou**
   
28. Return the **IActionResult** result using the **View** method. 


#### Task 4: Run the Application

1. View the contents of the **Create.cshtml** view.
    
2. Save all the changes.

3. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

4. Start the application without debugging.

5. In **Solution Explorer**, right-click **Server**, point to **Debug**, and then click **Start new instance**.
    
6. In the menu bar, click **Reservation**.

7. On **Reservation** page, create a new reservation with the following credentials:
   
    - Restaurant Branch: Select **_&lt;a restaurant branch of your choice&gt;_**
    - First Name: Type **_&lt;A first name of your choice&gt;_**
    - Last Name: Type **_&lt;A last name of your choice&gt;_**
    - Phone Number: Type **_&lt;A phone of your choice&gt;_** 
    - Reservation Time: Type **_&lt;An reservation time of your choice&gt;_** 
    - Dinner Guests: Type **_&lt;A dinner guests of your choice&gt;_** 
    
8. Click **Make a Reservation**.


### Exercise 3: Calling a Web API using jQuery

#### Scenario

In this exercise, you will first create a javaScript file. You will then add to the new javaScript file a jQuery and ajax script. After that you will call Web API Service GET method. Finally, you will add another javaScript file with javaScript file a jQuery and ajax script and call Web API Service POST method and run the application.

The main tasks for this exercise are as follows:

1. Calling a Web API Service GET method.

2. Run the Application.

3. Calling a Web API Service POST method.

4. Run the Application.

#### Task 1: Calling a Web API Service GET method

1. Create a new controller with the following information:
   - Controller name: **WantedAdController**
   - Template: **MVC Controller - Empty**
   - Folder: **Client/Controllers**
   
2. Add a **JavaScript** File with the following information:

   - Folder: **Client/wwwroot/js**
   - Name: **wanted-ad-get.js**
   
3. In the **wanted-ad-get.js** file, call the **$** function and pass an **anonymous function** as a parameter.

4. Inside the **anonymous function** code block, call the **$.ajax** function. Pass a **JSON** object as a parameter to the **$.ajax** function using the following information:

    - Properties: 
      - type: **"GET"**
      - url: **"http://localhost:54517/api/RestaurantWantedAd"**
      - contentType: **"application/json; charset=utf-8"**
      - dataType: **"json"**
      - success: **function(data) { }**      
      - error: **function() {  alert('An error has occurred'); }**

5. Inside the **anonymous function** code block assigned to the **success** property, call the **$.each** method. Pass **data** and **anonymous function** as parameters to the **$.each** method.

6. Change the signature of the **anonymous function** passed to the **$.each** method to accept **index** and **item** parameters.

7. Inside the **anonymous function** passed to the **$.each** method, add a variable of type **var** with the name of **html**. 

8. Assign the **html** variable with the value of: 
  ```cs
   `<div class="photo-index-card-data">
           <div class="image-wrapper">
                 <img class="photo-display-img" src="~/images/white-plate.jpg" />
           </div>
           <div class="display-picture-data">
                 <h6 class="display-title">Job Title:</h6>
                 <h6>${item.jobTitle}</h6>
                 <h6 class="display-title">Hourly payment:</h6>
                 <h6>$${item.pricePerHour}</h6>
                 <h6 class="display-title">Job Description:</h6>
                 <h6>${item.jobDescription}</h6>
           </div>
     </div>`
```

9. Call the **$** function and pass **'.container'** as a parameter.

10. Chain a **append** function call to the $ function call. Pass **html** as a parameter to the  **append** function.

11. Call the **$** function and pass **'.photo-display-img'** as a parameter.

12. Chain a **attr** function call to the $ function call. Pass **'src'** and '/images/white-plate.jpg' as parameters to the  **attr** function.

13. Inside the **WantedAd/Index.cshtml** view, after the **DIV** element with the **"container"** class, add a **Scripts** section code block.

14. In the **Scripts** section code block, add a **SCRIPT** element with the following information:

    - Src: **~/js/wanted-ad-get.js**


#### Task 2: Run the Application

1. Save all the changes.

2. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

3. Start the application without debugging.

4. In **Solution Explorer**, right-click **Server**, point to **Debug**, and then click **Start new instance**.
    
5. In the menu bar, click **We are Hiring**.
    >**Note:** The browser displays the **Index.cshtml** file content of the **WantedAdController**.

6. On **We are Hiring**, click **Submit Job Application**.
    >**Note:** We have not yet built the content of the page.


#### Task 3: Calling a Web API Service POST method

1. 


    

#### Task 4: Run the Application

1. View the contents of the **Create.cshtml** view.
    
2. Save all the changes.

3. In Solution Explorer, right-click **Client**, and then click **Set as StartUp Project**.

4. Start the application without debugging.

5. In **Solution Explorer**, right-click **Server**, point to **Debug**, and then click **Start new instance**.
    
6. In the menu bar, click **Submit Job Application**.

7. On **Submit Job Application** page, submiot a form with the following credentials:
   
    - Job Title: Select **_&lt;a job title of your choice&gt;_**
    - First Name: Type **_&lt;A first name of your choice&gt;_**
    - Last Name: Type **_&lt;A last name of your choice&gt;_**
    - Phone Number: Type **_&lt;A phone of your choice&gt;_** 
    - Email: Type **_&lt;An email time of your choice&gt;_** 
    - Address : Type **_&lt;An address of your choice&gt;_** 
    
8. Click **Apply For a Job**.

9. Close **Microsoft Edge**.

10. Close **Microsoft Visual Studio**.

>**Results** : After completing this exercise, you should have created a cupcakes shop application in which users can add a new cupcake, edit a cupcake, delete a cupcake and view a cupcake’s details.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
