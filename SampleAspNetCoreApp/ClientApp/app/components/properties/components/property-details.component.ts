import { Component, OnInit } from '@angular/core';
import { Property } from '../../../models/property';
import { PropertiesService } from '../services/propertiesservice';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';


@Component({
    templateUrl: './property-details.component.html'
})

export class PropertyDetailsComponent implements OnInit {

    constructor(
        private propertiesService: PropertiesService,
        private activatedRoute: ActivatedRoute,
        private location: Location
    ) { }
    pageTitle: string;
    urlParam: number;
    isInEditMode: boolean = true;
    property = new Property();
    ngOnInit(): void {
        this.detectUtlParam();
        if (this.location.isCurrentPathEqualTo("/properties/new-property")) {
            this.pageTitle = "New property";
        }
        else if (this.location.isCurrentPathEqualTo("/properties/property-update")) {
            this.pageTitle = "Update property";
            this.downloadProperty();
        } else {
            this.pageTitle = "Property details";
            this.downloadProperty();
            this.isInEditMode = false;
        }
       
    }
    downloadProperty(): void {
        this.propertiesService.getProperty(this.urlParam).subscribe(
            propertyFromDb => {this.property = propertyFromDb},
            errorObj => {console.log(errorObj)}
        );
        
    }
    detectUtlParam(): void {
        this.activatedRoute.params.subscribe(params => {
            this.urlParam = params["id"];
        });
        
    }
    onSubmit(property: Property): void {
        if (this.location.isCurrentPathEqualTo("/properties/new-property")) {
            property.addressId = 1;
            property.ownerId = 1;
            this.propertiesService.addProperty(property).subscribe(
                onSuccess => console.log(onSuccess),
                onError => console.log(onError)
            );
        } else {
            this.propertiesService.updateProperty(property).subscribe(
                onSuccess => console.log(onSuccess),
                onError => console.log(onError)
            );
        }
    }
    goBack(): void {
        this.location.back();
    }
}