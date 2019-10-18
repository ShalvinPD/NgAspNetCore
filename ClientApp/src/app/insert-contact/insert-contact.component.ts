import { Component, OnInit } from '@angular/core';
import { Contact } from '../contact';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-insert-contact',
  templateUrl: './insert-contact.component.html',
  styleUrls: ['./insert-contact.component.css']
})
export class InsertContactComponent implements OnInit {

  contact: Contact = new Contact;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  save(){
    this.http.post<Contact>("https://localhost:5001/api/contacts", this.contact)
    .subscribe();
    alert('Record Saved');
  }

}
