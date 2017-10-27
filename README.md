# _Maya's Specialty Foods_

#### _Program extends an online presence for Maya's Specialty Foods, October 27, 2017_

#### By _**Kim Schulze**_

## Description

_The program uses .Net technologies to build a website that can act as an online presence for Maya's Specialty Foods.  It allows users to easily navigate through the site, includes a landing page with the three most recently added products, and the three products with the most reviews.  Products can be added with a name, cost, and country of origin.  All reviews have a content body, author, and rating.  The relationship between products and reviews is one-to-many._

_The program includes an Admin section for employees to create an account, login, and logout.  The admin view allows the user to create, edit, and delete products."

## Setup/Installation Requirements

* _Use an up-to-date browser._
* _Requires SQL server.  This program runs MAMP._
* _To Install NuGet Packages._

Microsoft.EntityFrameworkCore - Version 1.1.2
Pomelo.EntityFrameworkCore.MySql Version - 1.1.2

## Specifications
* Using .NET Core Identity, Employees at Mario's Speciality Food Products can register for admin accounts.
* Employees can log in and out of their accounts.
* Admin users are allowed to post new items.
* Anonymous users should not be able to post new items.
* Admin users can delete comments by any user.
* From the product details page, make adding a new review into an AJAX action.


| Behavior | Input | Output | Reasoning |
| ---- | ---- | ---- | ---- |
| 1. Site allows admins to add a new product. | Name: Maya's Asparagus Enchiladas, Cost: 9.95, Country_of_Origin: United States of America | Name: Maya's Asparagus Enchiladas, Cost: 9.95, Country_of_Origin: United States of America| Products are the lifeblood of this site and need to be added. |
| 2. Site allows admins to update a new product. | Name: Maya's Asparagus Enchiladas, Cost: 11.95, Country_of_Origin: United States of America | Name: Maya's Asparagus Enchiladas, Cost: 11.95, Country_of_Origin: United States of America | Allows user to update existing product since changes sometimes are needed. |
| 3. Site allows admins to delete a new product. | Press Delete | Product disappears from database and website list | Allows for completed CRUD functionality. |
| 4. Site allows users to add a new review to a Product. | Site allows users to update a review. | Author: Maya Bat Chava, Content_Body: These Enchiladas are delish! The best thing since sliced-bread! Rating: 5/5 | Gusto Gummi disappears from products list. | Author: Maya Bat Chava, Content_Body: These Enchiladas are delish! Rating: 5/5 | Reviews must be attached to products as part of communication tool. |
| 5. Site allows users to update a review. | Author: Maya Bat Chava, Content_Body: These Enchiladas are delish! The best thing since sliced-bread! Yes. Rating: 5/5 | Gusto Gummi disappears from products list. | Site allows users to update a review. | Author: Maya Bat Chava, Content_Body: These Enchiladas are delish! The best thing since sliced-bread! Yes. Rating: 5/5 | Gusto Gummi disappears from products list. | A mistake might be made to change. |
| 6. Site allows users to delete a review. | Click on delete. | Review disappears from site and database | Complete CRUD. |
| 7. Review's content is between 50 and 250 characters. | Site allows users to update a review. | Author: Maya Bat Chava, Content_Body: Well, I like it. Rating: 5/5 | Gusto Gummi disappears from products list. | | | |
| 8. The Controller returns products in dedicated route. | Go to products route. | Return products | Test products controller. |
| 9. The Controller returns reviews in a dedicated route. | Go to Reviews. | Return Reviews.| Test reviews controller. |
| 7. Site calculates average rating for a product. | Ratings: 5, 5, 2 | Average Rating: 4 | Utilize and summarize review data. |
| 8. Landing page displays three most recently added products. | go to landing page. | display most recent items | test that the user is properly informed. |
| 9. Landing page displays three products with the most ratings. | go to landing page. | display products with the most reviews. | test that the user is properly informed. |

## Known Bugs

_There are no known bugs._

## Support and contact details

_With questions contact Kim Schulze at kimberlykayschulze@gmail.com._

## Technologies Used

_Used Visual Studio with C#, .NET, MVC, and HTML. Included MAMP for MySQL and entity frameworks._

### License

*All Rights Reserved.  Version 1.0*
