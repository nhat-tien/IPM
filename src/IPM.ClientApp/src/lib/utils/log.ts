
export class AppLog {

  public static error(message: string, placeOccur?: string) {
    console.table({ "[ERROR]": message, "Place occur": placeOccur});
  }

  public static cache(message: string) {
    console.log(`[CACHE]: ` + message);
  }

  public static info(message: string) {
    console.log(`[INFO]: ` + message);
  }

  public static refreshToken(message: string) {
    console.log(`[REFRESH_TOKEN]: ` + message);
  }

}
