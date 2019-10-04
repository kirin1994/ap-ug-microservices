import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Eventer } from './eventer';


@Component({
  templateUrl: './add-event.component.html',
})

export class AddEventComponent  {
  constructor (private http: HttpClient) {}
  
  onSubmit(name:HTMLInputElement, description:HTMLInputElement){
    let event = new Eventer(name.value,description.value);
    console.log(event);
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8')
    headers = headers.set('Access-Control-Allow-Origin' , '*');

    var ip = window.location.hostname;
    var address = "http://" + ip + ":31001/api/gateway";
    console.log(address);  
    this.http.post(address, event ,{headers}).subscribe(data => console.log(data));
  }
}
