import { Component, OnInit } from '@angular/core';

@Component({
    moduleId: module.id,
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
    username: string;
    errormessage = '';

    constructor() {
      const currentUser = JSON.parse(localStorage.getItem('currentUser'));
      this.username = currentUser && currentUser.username;
    }

    ngOnInit() {

    }

}
