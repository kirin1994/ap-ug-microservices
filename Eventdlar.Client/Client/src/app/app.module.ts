import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {RouterModule, Routes} from '@angular/router';
import { AppComponent } from './app.component';
import { EventListComponent } from './Events/event-list.component';
import { NotificationListComponent } from './Notifications/notification-list.component';
import { AddEventComponent } from './Events/add-event.component';
import { HomeComponent } from './Home/home.component';
import { HttpClientModule } from '@angular/common/http';

const appRoutes: Routes =
[
  
  {path: 'events', component: EventListComponent},
  {path: 'add-event', component: AddEventComponent},
  {path: 'notifications', component: NotificationListComponent},
  {path: 'home', component: HomeComponent},
  {path: '', redirectTo: 'home',  pathMatch: 'full'}
];

@NgModule({
  imports:      [ 
    RouterModule.forRoot(
      appRoutes
    ),
    ReactiveFormsModule,
    HttpClientModule,
    BrowserModule, FormsModule ],
  declarations: [ AppComponent, EventListComponent, NotificationListComponent, HomeComponent, AddEventComponent  ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
