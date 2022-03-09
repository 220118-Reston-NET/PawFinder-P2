import { PawfinderService } from './../services/pawfinder.service';
import { Users } from './../models/users.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  title:string = "List of Users";
    src1:string = "https://upload.wikimedia.org/wikipedia/commons/6/6a/Door_Tree_1898.png";
    isVisible:boolean = true;

    filteredName:string = "";

    listOfUsers:Users[];
    filteredListOfUser:Users[];

    constructor(private service: PawfinderService){
        this.listOfUsers = [];
        this.filteredListOfUser = [];

        this.service.getAllUsers().subscribe(result => {
            console.log(result);
            this.listOfUsers = result;
            // result.forEach(Users=>Users.UserSize);
            this.filteredListOfUser = result;
        });
    }

    changeTitle()
    {
        this.title = "title has been changed!";
        this.src1 = "https://upload.wikimedia.org/wikipedia/commons/5/56/Hudson_Yards_from_Hudson_Commons_%2895131p%29.jpg";
        // this.listOfPokemon.push({base_experience:64, id:1,name:'bulbasaur',sprites:{front_default:'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png'}});
    }

    changeVisible()
    {
        this.isVisible = !this.isVisible;
    }

    public set FilteredName(s1:string)
    {
        this.filteredName = s1;
        this.filteredListOfUser = this.filteredName ? this.performFilter(this.filteredName) : this.listOfUsers;
    }

    performFilter(filter:string):Users[]
    {
        filter = filter.toLowerCase();

        let tempListOfUsers:Users[]

        tempListOfUsers = this.listOfUsers.filter((Users:Users) => Users.userName.toLowerCase().indexOf(filter) != -1);

        return tempListOfUsers;
    }

}
