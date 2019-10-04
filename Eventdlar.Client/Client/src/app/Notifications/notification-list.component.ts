import {Component} from '@angular/core'
import {Notification} from './notification'

@Component({
  templateUrl: "./notification-list.component.html"
})
export class NotificationListComponent{
  notifications = [
    new Notification(1,'malpa@com.pl','Udala sie notyfikacja'),
    new Notification(1,'malpaaa@com.pl','Notyfikacja'),
    new Notification(1,'malpatrzecia@com.pl','Kotyfikacja'),
    new Notification(1,'malpatestowa@com.pl','Elotyfikacja')
  ]
}