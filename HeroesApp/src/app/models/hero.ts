export class Hero {
    id: number;
    name: string;
    bio: string;
    image: string;
    firstAppearance: Date;
    homeId: number
    home: HeroHome;
}

export class HeroHome {
    id: number;
    name: string;
    image: string;
}