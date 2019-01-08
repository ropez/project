<h3>MovieApi</h3>
<p>
A REST api for retrieving data about movies and actors.
<br><br>
Uses an Entity framework code-first generated database, where some junction tables
have been created automatically, which enables us to use Linq navigational properties.
The tables of the databases is explained in the file db.cs, and the data structure of all the
tables is contained in the models folder.
<br><br>
The api contains the following endpoints:
<br><br>
api/Actors/id<br>
api/Actors/id/credits<br>
api/movies/id<br>
api/movies/id/credits<br>
api/movies/popular?pageNum=&pageSize=<br>
api/search?key=&pageNum&pageSize<br>
</p>
------------------------------------------------<br>
All responses are in JSON format
<p><br>
<strong>api/Actors/id</strong>
</p>
Returns details about an actor with a given id:
<br><br>
ActorId : Integer<br>
Name : String<br>
BirthDate : String or null<br>
DeathDate : String or null<br>
Description : String, can be empty<br>
ImageUrl : String or null<br>
<p><br>
<strong>api/Actors/id/credits</strong>
</p>
Returns an array of the movies the actor starred in.<br>
Empty if no matches.<br>
<br>
Id : Integer<br>
Key : String (Title)<br>
Img : String or null<br>
Date : String or null (Release date)<br>
<p><br>
<strong>api/movies/id</strong>
</p>
MovieId : Integer<br>
Title : String<br>
Description : String, can be empty<br>
PosterUrl : String or null<br>
Released : String or null<br>
BackDropUrl : String or null<br>
Genres : Array of strings or null<br>
Directors : Array of strings or null<br>
<p><br>
<strong>api/movies/id/credits</strong>
</p>
An array of actors, empty if no matches<br>
<br>
Id : Integer<br>
Key : String (Title)<br>
Img : String or null<br>
Date : String or null<br>
Character : String<br>
<p><br>
<strong>api/movies/popular?pageNum=&pageSize=</strong>
<p>
An array of the highest rated movies in the database sorted.<br>
Empty if none;<br>
<br>
Id: Integer<br>
Title : String<br>
Rating : Number<br>
PosterUrl : String or empty<br>
Genres : Array of strings<br>
<p>
<strong>api/search?key=&pageNum&pageSize</strong>
</p>
Count : Number (of matches in database)<br>
Page :  (Array of matches)<br>
    Type : String ('movie' or 'actor')<br>
    Key : String  (Title or Name)<br>
    Id : Integer<br>
    Img : String or null<br>
    Date : String or null<br>
<br>
------------
<br>
<h3>Vue-FrontEnd (Movezz)</h3><br>

Frontend web app made with Vue, Vue router and Vue Resource, which uses the API.<br>
<br>
- Contains a home page, where one can see highly rated movies, and click on them to be routed to a details page<br>
- Searchbar where one can search for movies and actors<br>
- Actor and Movie pages where one can see details about the actor/movie and their credits.<br>
