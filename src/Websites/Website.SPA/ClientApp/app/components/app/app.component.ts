import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Meta } from "@angular/platform-browser";

@Component({
    selector: "app",
    templateUrl: "./app.component.html"
})

export class AppComponent {
    private serviceUrl: string = "api/application";
    data: any;

    constructor(private readonly http: HttpClient, private readonly meta: Meta) {
    }

    ngOnInit(): void {
        this.http.get(this.serviceUrl + "/GetWebsite").subscribe(result => this.data = result);
        //this.meta.addTag({ name: 'title', content: this.data.website.name });
    }
}