#!/bin/bash

# #############################################################################
# Settings
#
nugetFeedUri="https://www.myget.org/F/envoice/api/v2"
nugetKey=$MYGET_KEY_ENVOICE
nugetVersion="1.0.2"
nugetVersionSuffix=""

BLUE="\033[00;34m"
GREEN='\033[00;32m'
RED='\033[00;31m'
RESTORE='\033[0m'
YELLOW='\033[00;33m'


# #############################################################################
# Welcome message
#
welcome () {

  echo -en "${BLUE}\n"
  echo -en "                         _          \n"
  echo -en "  ___  ____ _   ______  (_)_______  \n"
  echo -en " / _ \/ __ \ | / / __ \/ / ___/ _ \ \n"
  echo -en "/  __/ / / / |/ / /_/ / / /__/  __/ \n"
  echo -en "\___/_/ /_/|___/\____/_/\___/\___/ ™\n"
  echo -en "${RESTORE}\n"

}


# #############################################################################
# Builds the project.
#
buildProject () {

  echo -en "${GREEN}\n"
  echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -e "+ Building project                              "
  echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -en "${RESTORE}\n"

  dotnet restore
  dotnet build
}


# #############################################################################
# Cleans all project files
#
cleanAll() {

  echo -en "${GREEN}\n"
  echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -e "+ Cleaning project                              "
  echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -en "${RESTORE}\n"

  dotnet clean
}


# #############################################################################
# Deploys nuget packages to nuget feed
#
nugetPublish () {

  echo -en "${GREEN}\n"
  echo -e  "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -e  "+ Deploying nuget packages to nuget feed        "
  echo -e  "+ $nugetUri                                     "
  echo -e  "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -en "${RESTORE}\n"

  if [ -z "$nugetKey" ]; then
    echo -en "${RED}\n"
    echo "You must set the MYGET_KEY_ENVOICE environment variable"
    echo -en "${RESTORE}\n"
    exit 1
  fi

  echo -en "${YELLOW} Using Key: $nugetKey ${RESTORE} \n"

  if [[ -z $ENVIRONMENT ]]; then
    ENVIRONMENT="debug"
  fi

  shopt -s nullglob # hide hidden

  cd src

  for dir in */ ; do # iterate projects
    [ -e "$dir" ] || continue

    cd $dir

    for nuspec in *.nuspec; do

      echo -e "\nFound nuspec for ${dir::-1}"

      if [ -z "$nugetVersionSuffix" ]; then

        dotnet pack \
          -c $ENVIRONMENT \
          --include-source \
          --include-symbols

        echo -en "${YELLOW}\n"
        echo -en "Publishing: ${dir::-1}.$nugetVersion"
        echo -en "${RESTORE}\n"

        curl \
          -H 'Content-Type: application/octet-stream' \
          -H "X-NuGet-ApiKey: $nugetKey" \
          $nugetFeedUri \
          --upload-file bin/$ENVIRONMENT/${dir::-1}.$nugetVersion.nupkg

      else

        dotnet pack \
          -c $ENVIRONMENT \
          --include-source \
          --include-symbols \
          --version-suffix $nugetVersionSuffix

        echo -en "${YELLOW}\n"
        echo -en "Publishing: ${dir::-1}.$nugetVersion-$nugetVersionSuffix"
        echo -en "${RESTORE}\n"

        curl \
          -H 'Content-Type: application/octet-stream' \
          -H "X-NuGet-ApiKey: $nugetKey" \
          $nugetFeedUri \
          --upload-file bin/$ENVIRONMENT/${dir::-1}.$nugetVersion-$nugetVersionSuffix.nupkg

      fi

      echo -en "${GREEN} \n"
      echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
      echo -e "Uploaded package for ${dir::-1}                 "
      echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
      echo -en "${RESTORE}\n"

    done

    cd ..

  done

}


# #############################################################################
# Runs the unit tests
#
unitTests () {

  echo -en "${GREEN}\n"
  echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -e "+ Running unit tests                            "
  echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
  echo -en "${RESTORE}\n"

  for dir in test/*.Tests*/ ; do
    [ -e "$dir" ] || continue
    dir=${dir%*/}
    echo -e ${dir##*/}
    cd $dir
    dotnet test -c $ENVIRONMENT
    rtn=$?
    if [ "$rtn" != "0" ]; then
      exit $rtn
    fi
  done

}

# #############################################################################
# Shows the usage for the script
#
showUsage () {
  echo -en "${YELLOW}"
  echo -e "Usage: project-tasks.sh [COMMAND] (ENVIRONMENT)"
  echo -e "    Runs build or compose using specific environment (if not provided, debug environment is used)"
  echo -e ""
  echo -e "Commands:"
  echo -e "    build: Builds the project."
  echo -e "    clean: Cleans the project files"
  echo -e "    nugetPublish: Builds and packs the project and publishes to nuget feed."
  echo -e "    unitTests: Runs all unit test projects with *UnitTests* in the project name."
  echo -e ""
  echo -e "Environments:"
  echo -e "    debug: Uses debug environment."
  echo -e "    release: Uses release environment."
  echo -e ""
  echo -e "Example:"
  echo -e "    ./project-tasks.sh build debug"
  echo -e ""
  echo -en "${RESTORE}"
}


# #############################################################################
# Switch arguments
#
if [ $# -eq 0 ]; then
  showUsage
else

  welcome
  ENVIRONMENT=$(echo -e $2 | tr "[:upper:]" "[:lower:]")

  case "$1" in
    "build")
            buildProject
            buildImage
            ;;
    "clean")
            cleanAll
            ;;
    "nugetPublish")
            buildProject
            nugetPublish
            ;;
    "unitTests")
            unitTests
            ;;
    *)
            showUsage
            ;;
  esac

fi


# #############################################################################
