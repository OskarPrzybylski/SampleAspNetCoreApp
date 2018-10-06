import { Component, OnInit } from '@angular/core';
import { Property } from '../../models/property';
import { PropertiesService } from './services/propertiesservice';


@Component({
    templateUrl: "./properties.component.html"
})

export class PropertiesComponent implements OnInit {
    constructor(private propertiesService: PropertiesService) {}
    ngOnInit(): void {
        var testowaZmienna = "Pozdro z komponentu";
        this.propertiesService.getProperties().subscribe(
            props => {
                console.log("Properties:", props)
            },
            error => { console.log("Error: ", error) }
        );
    }
}