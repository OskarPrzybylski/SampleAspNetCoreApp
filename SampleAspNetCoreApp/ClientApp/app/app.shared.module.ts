import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

//***PropertiesSection***\\
import { PropertiesComponent } from "./components/properties/components/properties.component";
import { PropertiesService } from "./components/properties/services/propertiesservice";
import { PropertiesBackendService } from "./services/propertiesbackendservice";
import { HttpPropertiesBackendService } from "./services/httppropertiesbackendservice";
import { PropertyDetailsComponent } from "./components/properties/components/property-details.component";





@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        PropertiesComponent,
        PropertyDetailsComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'properties', component: PropertiesComponent },
            { path: "properties/new-property", component: PropertyDetailsComponent },
            { path: "properties/property-details/:id", component: PropertyDetailsComponent },
            {path: "properties/property-update/:id", component: PropertyDetailsComponent},
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        PropertiesService,
        {provide: PropertiesBackendService, useClass: HttpPropertiesBackendService}
        ]
})
export class AppModuleShared {
}
