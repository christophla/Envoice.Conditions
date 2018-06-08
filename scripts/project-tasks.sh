#!/bin/bash

# #############################################################################
# Settings
#
branch=$(if [ "$TRAVIS_PULL_REQUEST" == "false" ]; then echo $TRAVIS_BRANCH; else echo $TRAVIS_PULL_REQUEST_BRANCH; fi)
# nugetFeedUri="https://api.nuget.org/v3/index.json"
nugetFeedUri="https://www.myget.org/F/envoice/api/v3/index.json"
nugetKey=$MYGET_KEY_ENVOICE
packageVersion=1.0.1
revision=${TRAVIS_BUILD_NUMBER:=1}

BLUE="\033[00;34m"
GREEN='\033[00;32m'
RED='\033[00;31m'
RESTORE='\033[0m'
YELLOW='\033[00;33m'
ROOT_DIR=$(pwd)


# #############################################################################
# Welcome message
#
welcome () {

    echo -e "${BLUE}"
    echo -e "                         _           "
    echo -e "  ___  ____ _   ______  (_)_______   "
    echo -e " / _ \/ __ \ | / / __ \/ / ___/ _ \  "
    echo -e "/  __/ / / / |/ / /_/ / / /__/  __/  "
    echo -e "\___/_/ /_/|___/\____/_/\___/\___/ ™ "
    echo -e "${RESTORE}"

}


# #############################################################################
# Builds the project
#
buildProject () {

    echo -e "${GREEN}"
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "+ Building project                              "
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "${RESTORE}"

    dotnet restore
    dotnet build -c $ENVIRONMENT
}


# #############################################################################
# Cleans the project
#
cleanAll() {

    echo -e "${GREEN}"
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "+ Cleaning project                              "
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "${RESTORE}"

    dotnet clean
}


# #############################################################################
# Deploys nuget packages to nuget feed
#
nugetPublish () {

    echo -e "${GREEN}"
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "+ Deploying nuget packages to Nuget feed        "
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "${RESTORE}"

    if [ -z "$nugetKey" ]; then
        echo "${RED}You must set the NUGET_KEY_ENVOICE environment variable${RESTORE}"
        exit 1
    fi

    suffix=$(if [ "$branch" != "master" ]; then echo "ci-$revision"; fi)

    shopt -s nullglob # hide hidden
    cd src

    for dir in */ ; do # iterate projects
        [ -e "$dir" ] || continue

        cd $dir

        for nuspec in *.nuspec; do

            echo -e "${GREEN}Found nuspec for ${dir::-1}${RESTORE}"

            if ([ "$branch" == "master" ]); then
                dotnet pack \
                    -c $ENVIRONMENT \
                    -o ../../.artifacts/nuget \
                    --include-source \
                    --include-symbols
            else
                dotnet pack \
                    -c $ENVIRONMENT \
                    -o ../../.artifacts/nuget \
                    --include-source \
                    --include-symbols \
                    --version-suffix $suffix
            fi

            echo -e "${GREEN}"
            echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
            echo -e "Uploaded nuspec for ${dir::-1}                  "
            echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
            echo -e "${RESTORE}"

        done

        cd ..

    done

    echo -e "${YELLOW}Publishing packages to ${nugetFeedUri}${RESTORE}"

    cd $ROOT_DIR
    cd ./.artifacts/nuget

    dotnet nuget push *.nupkg \
        -k $nugetKey \
        -s $nugetFeedUri

    cd $ROOT_DIR

    rm -rf ./artifacts/nuget
}


# #############################################################################
# Runs the unit tests.
#
unitTests () {

    echo -e "${GREEN}"
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "+ Running unit tests                            "
    echo -e "++++++++++++++++++++++++++++++++++++++++++++++++"
    echo -e "${RESTORE}"

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

    cd $ROOT_DIR
}


# #############################################################################
# Shows the usage for the script.
#
showUsage () {
    echo -e "${YELLOW}"
    echo -e "Usage: project-tasks.sh [COMMAND] (ENVIRONMENT)"
    echo -e "    Runs build or compose using specific environment (if not provided, debug environment is used)"
    echo -e ""
    echo -e "Commands:"
    echo -e "    build: Builds the project."
    echo -e "    build-ci: Builds the project for CI server."
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
    echo -e "${RESTORE}"
}


# #############################################################################
# Switch arguments
#
if [ $# -eq 0 ]; then
    showUsage
else
    ENVIRONMENT=$(echo -e $2 | tr "[:upper:]" "[:lower:]")
    if [[ -z $ENVIRONMENT ]]; then ENVIRONMENT="debug"; fi

    welcome
    case "$1" in
        "build")
            buildProject
            buildImage
            ;;
        "build-ci")
            unitTests
            nugetPublish
            ;;
        "clean")
            cleanAll
            ;;
        "nugetPublish")
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
