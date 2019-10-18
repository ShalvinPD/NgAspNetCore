import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Contact } from '../contact';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  contacts: Contact[];
  selectedContact: Contact;
  constructor(private http: HttpClient) { }

  ngOnInit() {
   this.showData();

  }
  
  showData(){
    this.http.get<Contact[]>("https://localhost:5001/api/contacts")
    .subscribe(contacts => this.contacts = contacts);
  }


  onSelect(id: number){
    this.http.get<Contact>("https://localhost:5001/api/contacts/"  + id)
    .subscribe(selectedContact => this.selectedContact = selectedContact);
  }

  
}
