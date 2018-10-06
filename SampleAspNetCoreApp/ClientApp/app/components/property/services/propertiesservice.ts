import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Property } from "../../../models/property";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/map";
import { PropertiesBackendService } from "../../../services/propertiesbackendservice";


@Injectable()
export class PropertiesService
{
    constructor(private propertiesBackendService: PropertiesBackendService) {}
    addProperty(newProperty: Property): Observable<number> {
        return this.propertiesBackendService.addProperty(newProperty);
    }
    getProperty(propertyId: number): Observable<Property> {
        return this.propertiesBackendService.getProperty(propertyId);
    }
    getProperties(): Observable<Property[]> {
        return this.propertiesBackendService.getProperties();
    }
    updateProperty(updatedProperty: Property): Observable<number> {
        return this.propertiesBackendService.updateProperty(updatedProperty);
    }
    deleteProperty(propertyId: number): Observable<number> {
        return this.propertiesBackendService.deleteProperty(propertyId);
    }

}