import { Component } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'my-app',
  styleUrls: [ './app.component.css' ],
  templateUrl: './app.component.html',
})

export class AppComponent  {
  name = 'Angular';
  constructor (private http: HttpClient) {}
  test(){
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'text/plain; charset=utf-8')
    headers = headers.set('Access-Control-Allow-Origin' , '*');

    var ip = window.location.hostname;
    var address = "http://" + ip + ":31001/api/values";
    console.log(address);  
    this.http.get(address, {headers}).subscribe(data => console.log(data));
  }
}
