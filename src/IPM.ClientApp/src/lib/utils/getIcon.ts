import icons from "@utils/fileTypeIcons";

export default function getIcon(filename: string){
		if (!filename) {return icons.default}
		return Object.entries(icons).find(
			i => i[0]
				.split(",")
				.includes(filename.split(".").slice(-1)[0])
		)?.[1] || icons.default;
}

