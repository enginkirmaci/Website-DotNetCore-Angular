import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";

import { ContentModule } from "./modules/content/content.module";
import { PagelistModule } from "./modules/pagelist/pagelist.module";
import { CommentsModule } from "./modules/comments/comments.module";
import { GalleryModule } from "./modules/gallery/gallery.module";

import { SharedModule } from "./modules/shared/shared.module";

import { AppComponent } from "./components/app/app.component";
import { PageComponent } from "./components/main/page.component";

@NgModule({
    declarations: [
        AppComponent,
        PageComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        ContentModule,
        PagelistModule,
        CommentsModule,
        GalleryModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "**", component: PageComponent }
        ])
    ]
})
export class AppModuleShared { }