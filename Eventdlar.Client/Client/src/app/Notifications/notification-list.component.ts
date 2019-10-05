import {Component} from '@angular/core'
import { NotificationList } from './notifications-list';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs'
import { NotificationMessage } from './notification';

@Component({
  templateUrl: "./notification-list.component.html"
})
export class NotificationListComponent{
  constructor(private http: HttpClient){}

  notifications: NotificationMessage[];

  ngOnInit(){
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8')
    headers = headers.set('Access-Control-Allow-Origin' , '*');

    let ip = window.location.hostname;
    let address = "http://" + ip + ":31001/api/gateway/notifications";
    console.log(address);  
    this.http.get<NotificationList>(address,{headers}).subscribe(data => this.notifications = data.notificationsList); 
  }
}