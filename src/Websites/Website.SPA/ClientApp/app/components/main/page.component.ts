import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router, NavigationEnd } from "@angular/router";
import { Meta } from "@angular/platform-browser";

@Component({
    selector: "app-page",
    templateUrl: "./page.component.html"
})
export class PageComponent implements OnInit {
    private serviceUrl: string = "api/application";
    data: any;

    constructor(private readonly router: Router, private readonly http: HttpClient, private readonly meta: Meta) { }

    ngOnInit() {
        this.redirectToPage(this.router.url);

        this.router.events.subscribe(route => {
            if (route instanceof NavigationEnd) {
                this.redirectToPage(route.url);
            }
        });
    }

    redirectToPage(url: string) {
        this.getCurrentPage();
    }

    getCurrentPage() {
        this.http.get(this.serviceUrl + "/GetCurrentPage").subscribe(result => this.data = result);

        //const currentTitle = this.meta.getTag("title");
        //const metaTitle: string = currentTitle + " - " + this.data.title;
        //this.meta.addTag({ name: "title", content: metaTitle });
    }
}

export interface IPageModel {
    page: any;
}