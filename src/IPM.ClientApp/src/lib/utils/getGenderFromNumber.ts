type GenderInfo = {
  vietnamese: string,
  english: string,
}


export const Gender: {[key in 0 | 1 | 2]: GenderInfo} = {
  0: {
    english: "Not known",
    vietnamese: "Không xác định",
   },
  1: {
    english: "Male",
    vietnamese: "Nam",
  },
  2: {
    english: "Female",
    vietnamese: "Nữ",
  }
}
