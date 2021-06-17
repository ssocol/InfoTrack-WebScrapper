import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { APP_ROUTINGS } from './app.routes';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { searchService } from './_services/search.service';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      NavbarComponent,
      SearchResultComponent,
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      APP_ROUTINGS
   ],
   providers: [
      searchService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
