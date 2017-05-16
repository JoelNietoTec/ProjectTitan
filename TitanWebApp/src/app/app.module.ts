import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

// Main Dependencies
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';

// Routers
import { AppRoutingModule } from './app-router.module';

// App Modules
import { HomeModule } from './home/home.module';
import { ParamsModule } from './params/params.module';
import { IndividualsModule } from './individuals/individuals.module';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CoreModule,
    HomeModule,
    ParamsModule,
    IndividualsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
