
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { QuillModule } from 'ngx-quill';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { WriterComponent } from './writer/writer.component';


import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from "@angular/common";
import localeVN from "@angular/common/locales/vi";

import { RoleService } from './services/role.service';
import { TopBarComponent } from './top-bar/top-bar.component';
import { LogoAreaComponent } from './logo-area/logo-area.component';
import { MenuAreaComponent } from './menu-area/menu-area.component';
import { HotNewsComponent } from './hot-news/hot-news.component';
import { DetailComponent } from './detail/detail.component';
import { ListNewsComponent } from './list-news/list-news.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RegisterComponent,
    LoginComponent,
    WriterComponent,
    TopBarComponent,
    LogoAreaComponent,
    MenuAreaComponent,
    HotNewsComponent,
    DetailComponent,
    ListNewsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    //JwtModule.forRoot({}),
    QuillModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      {
        path: 'writer', component: WriterComponent,
        canActivate: [RoleService],
        data: {
          expectedRole: 'Admin'
        }
      },
      { path: 'home', component: HomeComponent },
      { path: 'news/:id', component: DetailComponent },
      { path: 'category/:id/:pageNumber', component: ListNewsComponent },
      { path: 'category/:id', component: ListNewsComponent },
    ])
  ],
  providers: [{provide: LOCALE_ID, useValue: 'vi'}],
  bootstrap: [AppComponent]
})
export class AppModule { }

registerLocaleData(localeVN, "vi");
