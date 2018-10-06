import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Property } from "../models/property";
import { PropertiesBackendService } from '../services/propertiesbackendservice';
import { Http, RequestOptions, Headers, Response } from '@angular/http';

@Injectable()
export class HttpPropertiesBackendService extends PropertiesBackendService {
    private addPropertyUrl: string = "api/property/addproperty";
    private getPropertyUrl: string = "api/property/getproperty?id=";
    private getPropertiesUrl: string = "api/property/getproperties";
    private updatePropertyUrl: string = "api/property/updateproperty";
    private deletePropertyUrl: string = "api/property/deleteproperty?id=";
    private jsonContentOptions: RequestOptions;
    constructor(private http: Http) {
        super();
        let headersJson: Headers = new Headers({
            'Content-Type': 'application/json'
        });
        this.jsonContentOptions = new RequestOptions({headers: headersJson})
    }
    addProperty(newProperty: Property): Observable<number> {
        return this.http.post(this.addPropertyUrl,
            JSON.stringify(newProperty), this.jsonContentOptions).map(response => response.json() as number);
    }

    getProperty(id: number): Observable<Property> {
        return this.http.get(this.getPropertyUrl, JSON.stringify(id)).map(response => response.json() as Property);
    }

    getProperties(): Observable<Property[]> {
        return this.http.get(this.getPropertiesUrl).map(response => response.json() as Property[]);
    }

    updateProperty(updatedProperty: Property): Observable<number> {
        return this.http.post(this.updatePropertyUrl, JSON.stringify(updatedProperty), this.jsonContentOptions)
            .map(response => response.json() as number);
    }

    deleteProperty(propertyId: number): Observable<number> {
        return this.http.get(this.deletePropertyUrl, JSON.stringify(propertyId))
            .map(response => response.json() as number);
    }

}